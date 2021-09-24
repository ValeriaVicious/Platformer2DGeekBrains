using UnityEngine;


namespace PlatformerGeekBrains
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configs/" + nameof(PlayerConfig), order = 1)]
    public sealed class PlayerConfig : ScriptableObject
    {
        #region Fields

        public CharacterView View;
        public SpriteCharacterAnimationConfig SpriteAnimationsConfig;
        public int AnimationSpeed = 10;
        public float WalkSpeed = 70.0f;
        public float JumpForce = 8.0f;
        public float JumpStartSpeed = 5.0f;
        public float MovingThreshold = 0.1f;
        public float JumpThreshold = 0.1f;
        public float FlyThreshold = 1.0f;
        public float GroundLevel = 0.5f;

        #endregion
    }
}
