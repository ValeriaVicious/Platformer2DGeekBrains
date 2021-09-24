using UnityEngine;


namespace PlatformerGeekBrains
{
    public sealed class CameraController
    {
        #region Fields

        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;

        #endregion


        #region ClassLifeCycles

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _offset = _mainCamera.localPosition - _player.position;
            _offset.z = _mainCamera.localPosition.z;
        }

        #endregion


        #region Methods 

        public void Execute(float deltaTime)
        {
            _mainCamera.localPosition = _player.position + _offset;
        }

        #endregion
    }
}