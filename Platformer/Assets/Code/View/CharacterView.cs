using System;
using UnityEngine;
using PlatformerGeekBrains.Quests;


namespace PlatformerGeekBrains
{
    public sealed class CharacterView : LevelObjectView
    {
        #region Fields

        public Transform CharacterTransform;
        public SpriteRenderer CharacterSprite;
        public Collider2D CharacterCollider;
        public Rigidbody2D CharacterRigidbody;

        #endregion


        #region UnityMethods

        private void Start()
        {
            CharacterTransform = GetComponent<Transform>();
            CharacterSprite = GetComponent<SpriteRenderer>();
            CharacterRigidbody = GetComponent<Rigidbody2D>();
            CharacterCollider = GetComponent<Collider2D>();
        }

        #endregion
    }
}