using System.Collections.Generic;
using UnityEngine;


namespace PlatformerGeekBrains
{
    public sealed class BulletEmitterController
    {
        #region Fields

        private Transform _transform;
        private List<BulletController> _bullets = new List<BulletController>();
        private Vector3 _velocity = new Vector3();
        private const float _delay = 1.0f;
        private const float _startSpeed = 5.0f;
        private float _timeTillNextBullet;
        private int _currentIndex;

        #endregion


        #region ClassLifeCycles

        public BulletEmitterController(List<BulletView> bulletViews, Transform transform)
        {
            _transform = transform;
            foreach (var item in bulletViews)
            {
                _bullets.Add(new BulletController(item));
            }
        }

        #endregion

        #region Methods

        public void Execute(float deltaTime)
        {
            if (_timeTillNextBullet > 0)
            {
                _bullets[_currentIndex].SetActive(false);
                _timeTillNextBullet -= deltaTime;
            }
            else
            {
                _velocity = (_transform.up * -1.0f) * _startSpeed;
                _timeTillNextBullet = _delay;
                _bullets[_currentIndex].Throw(_transform.position, _velocity);
                _currentIndex++;

                if (_currentIndex >= _bullets.Count)
                {
                    _currentIndex = 0;
                }
            }
        }

        #endregion
    }
}