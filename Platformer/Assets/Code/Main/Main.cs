using UnityEngine;


namespace PlatformerGeekBrains
{
    public sealed class Main : MonoBehaviour
    {
        #region Fields

        [SerializeField] private SpriteCharacterAnimationConfig _playerAnimationsConfig;
        [SerializeField] private CharacterView _playerView;

        private SpriteAnimatorController _spriteAnimator;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _playerAnimationsConfig = Resources.Load<SpriteCharacterAnimationConfig>(Constants.SpriteAnimationsConfig);

            if (_playerAnimationsConfig)
            {
                _spriteAnimator = new SpriteAnimatorController(_playerAnimationsConfig);
            }

            if (_playerView)
            {
                _spriteAnimator.StartAnimation(_playerView.CharacterSprite, Track.Idle, true, 10.0f);
            }
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            _spriteAnimator.Execute();
        }

        private void FixedUpdate()
        {
            
        }

        #endregion
    }
}