using UnityEngine;
using System;


namespace PlatformerGeekBrains.Quests
{
    public sealed class QuestObjectView : LevelObjectView
    {
        #region Fields

        [SerializeField] private int ID;
        [SerializeField] private Color _completedColor;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider;
        private Color _defaultColor;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        #endregion


        #region Methods

        public void Complete()
        {
            _spriteRenderer.color = _completedColor;
        }

        public void Activate()
        {
            _spriteRenderer.color = _defaultColor;
        }

        #endregion
    }
}
