using UnityEngine;


namespace PlatformerGeekBrains
{
    public sealed class Main : MonoBehaviour
    {
        #region Fields

        [SerializeField] private SpriteCharacterAnimationConfig _playerAnimationsConfig;
        [SerializeField] private CharacterView _playerView;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private CannonView _cannonView;

        private CameraController _cameraController;
        private PlayerController _playerController;
        private CannonController _cannonController;
        private BulletEmitterController _bulletEmitterController;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            Camera camera = Camera.main;
            _playerAnimationsConfig = Resources.Load<SpriteCharacterAnimationConfig>(Constants.SpriteAnimationsConfig);
            _playerController = new PlayerController(_playerConfig, _playerView);
            _cameraController = new CameraController(_playerView.CharacterTransform, camera.transform);
            _cannonController = new CannonController(_cannonView.MuzzleTransform, _playerView.CharacterTransform);
            _bulletEmitterController = new BulletEmitterController(_cannonView.Bullets, _cannonView.EmmiterTransform);
        }


        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _cameraController.Execute(deltaTime);
            _cannonController.Execute(deltaTime);
            _bulletEmitterController.Execute(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            _playerController.FixedExecute(deltaTime);
        }

        #endregion
    }
}