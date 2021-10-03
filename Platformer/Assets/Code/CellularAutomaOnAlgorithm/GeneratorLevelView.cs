using UnityEngine;
using UnityEngine.Tilemaps;


namespace PlatformerGeekBrains.Level
{
    public sealed class GeneratorLevelView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Tilemap _tileMapGround;
        [SerializeField] private Tile _tileGround;
        [SerializeField] private int _widthMap;
        [SerializeField] private int _heightMap;
        [SerializeField] private int _factorSmooth;
        [SerializeField] [Range(0,100)] private int _randomFillPercent;

        #endregion


        #region Properties

        public Tilemap TileMapGround => _tileMapGround;

        public Tile TileGround => _tileGround;

        public int WidthMap => _widthMap;

        public int HeightMap => _heightMap;

        public int FactorSmooth => _factorSmooth;

        public int RandomFillPercent => _randomFillPercent;

        #endregion
    }
}