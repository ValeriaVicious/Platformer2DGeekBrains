using UnityEngine;


namespace PlatformerGeekBrains
{
    class PlayerController
    {
        #region Fields

        private readonly PlayerConfig _playerConfig;
        private readonly CharacterView _view;
        private readonly ContactPoller _contactPoller;
        private SpriteAnimatorController _spriteAnimator;
        private Vector3 _upVector = new Vector3(0.0f, 1.0f, 0.0f);
        private Vector3 _leftScale = new Vector3(-1.0f, 1.0f, 1.0f);
        private Vector3 _rightScale = new Vector3(1.0f, 1.0f, 1.0f);
        private float _yVelocity = 0.0f;
        private float _xVelocity = 0.0f;
        private float _xAxisInput;
        private bool _isJump;

        #endregion


        #region ClassLifeCycles

        public PlayerController(PlayerConfig player, CharacterView view)
        {
            _playerConfig = player;
            _view = view;
            _contactPoller = new ContactPoller(_view.CharacterCollider);
            _spriteAnimator = new SpriteAnimatorController(_playerConfig.SpriteAnimationsConfig);
        }

        #endregion


        #region Methods

        private void GoSideAway(float deltaTime)
        {
            _xVelocity = _playerConfig.WalkSpeed * deltaTime * (_xAxisInput < 0 ? -1.0f : 1.0f);
            _view.CharacterRigidbody.velocity = _view.CharacterRigidbody.velocity.Change(x: _xVelocity);
            _view.CharacterTransform.localScale = (_xAxisInput < 0.0f ? _leftScale : _rightScale);
        }

        public void FixedExecute(float deltaTime)
        {
            _spriteAnimator.Execute();
            _contactPoller.FixedExecute(deltaTime);
            _isJump = Input.GetAxis(Constants.VerticalInput) > 0.0f;
            _xAxisInput = Input.GetAxis(Constants.HorizontalInput);
            _yVelocity = _view.CharacterRigidbody.velocity.y;

            var goSideAway = Mathf.Abs(_xAxisInput) > _playerConfig.MovingThreshold;

            if (goSideAway)
            {
                GoSideAway(deltaTime);
            }

            if (_contactPoller.IsGrounded)
            {
                _spriteAnimator.StartAnimation(_view.CharacterSprite, goSideAway ? Track.Run : Track.Idle, true, _playerConfig.AnimationSpeed);

                if (_isJump && Mathf.Abs(_yVelocity) <= _playerConfig.JumpThreshold)
                {
                    _view.CharacterRigidbody.AddForce(_upVector * _playerConfig.JumpForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (goSideAway)
                {
                    GoSideAway(deltaTime);
                }
                if (Mathf.Abs(_yVelocity) > _playerConfig.JumpThreshold)
                {
                    _spriteAnimator.StartAnimation(_view.CharacterSprite, Track.Jump, true, _playerConfig.AnimationSpeed);
                }
            }
        }

        #endregion
    }
}