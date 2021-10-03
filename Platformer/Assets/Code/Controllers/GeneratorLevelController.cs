using System;
using UnityEngine;
using UnityEngine.Tilemaps;


namespace PlatformerGeekBrains.Level
{
    public sealed class GeneratorLevelController
    {
        #region Fields

        private const int _countWall = 4;
        private Tilemap _tileMapGround;
        private Tile _tileGround;
        private int _widthMap;
        private int _heightMap;
        private int _factorSmooth;
        private int _randomFillPercent;
        private int[,] _map;

        #endregion


        #region ClassLifeCycles

        public GeneratorLevelController(GeneratorLevelView generatorLevelView)
        {
            _tileMapGround = generatorLevelView.TileMapGround;
            _tileGround = generatorLevelView.TileGround;
            _widthMap = generatorLevelView.WidthMap;
            _heightMap = generatorLevelView.HeightMap;
            _factorSmooth = generatorLevelView.FactorSmooth;
            _randomFillPercent = generatorLevelView.RandomFillPercent;

            _map = new int[_widthMap, _heightMap];
        }

        #endregion


        #region Methods

        public void Awake()
        {
            GenerateTheLevel();
        }

        private void GenerateTheLevel()
        {
            RandomFillTheLevel();
            for (int i = 0; i < _factorSmooth; i++)
            {
                SmoothTheMap();
            }
            DrawTilesOnMap();
        }

        private void RandomFillTheLevel()
        {
            var seed = Time.time.ToString();
            var pseudoRandom = new System.Random(seed.GetHashCode());

            for (var x = 0; x < _widthMap; x++)
            {
                for (var y = 0; y < _heightMap; y++)
                {
                    if (x == 0 || x == _widthMap - 1 || y == 0 || y == _heightMap - 1)
                    {
                        _map[x, y] = 1;
                    }

                    else
                    {
                        _map[x, y] = (pseudoRandom.Next(0, 100) < _randomFillPercent) ? 1 : 0;
                    }
                }
            }

        }

        private void SmoothTheMap()
        {
            for (var x = 0; x < _widthMap; x++)
            {
                for (var y = 0; y < _heightMap; y++)
                {
                    var neighbourWallTiles = GetSurroundingWallCount(x, y);

                    if (neighbourWallTiles > _countWall)
                    {
                        _map[x, y] = 1;
                    }
                    else if (neighbourWallTiles < _countWall)
                    {
                        _map[x, y] = 0;
                    }
                }
            }

        }

        private void DrawTilesOnMap()
        {
            if (_map == null)
            {
                return;
            }

            for (var x = 0; x < _widthMap; x++)
            {
                for (var y = 0; y < _heightMap; y++)
                {
                    var positionTile = new Vector3Int(-_widthMap / 2 + x, -_heightMap / 2 + y, 0);

                    if (_map[x, y] == 1)
                    {
                        _tileMapGround.SetTile(positionTile, _tileGround);
                    }
                }
            }

        }

        private int GetSurroundingWallCount(int gridX, int gridY)
        {
            var wallCount = 0;

            for (var neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
            {
                for (var neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
                {
                    if (neighbourX >= 0 && neighbourX < _widthMap && neighbourY >= 0 && neighbourY < _heightMap)
                    {
                        if (neighbourX != gridX || neighbourY != gridY)
                            wallCount += _map[neighbourX, neighbourY];
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount;
        }


        #endregion
    }
}
