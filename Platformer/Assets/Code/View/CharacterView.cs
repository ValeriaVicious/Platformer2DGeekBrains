using System;
using UnityEngine;


namespace PlatformerGeekBrains
{
    public sealed class CharacterView : MonoBehaviour
    {
        #region Fields

        public Transform CharacterTransform;
        public SpriteRenderer CharacterSprite;
        public Collider2D CharacterCollider;
        public Rigidbody2D CharacterRigidbody;

        #endregion


        #region Properties

        public Action<CharacterView> OnLevelObjectContact { get; set; }

        #endregion


        #region UnityMethods

        private void Start()
        {
            CharacterTransform = GetComponent<Transform>();
            CharacterSprite = GetComponent<SpriteRenderer>();
            CharacterRigidbody = GetComponent<Rigidbody2D>();
            CharacterCollider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            CharacterView characterView = collision.GetComponent<CharacterView>();
            OnLevelObjectContact?.Invoke(characterView);
        }

        #endregion
    }
}