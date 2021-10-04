using UnityEngine;
using System;


namespace PlatformerGeekBrains.Quests
{
    public sealed class QuestObjectView : MonoBehaviour
    {
        #region Fields

        [SerializeField] private int ID;
        [SerializeField] private Color _completedColor;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider;
        private Color _defaultColor;


        #endregion


        #region Properties

        public Action<QuestObjectView> OnLevelObjectContact { get; set; }

        #endregion


        #region UnityMethods

        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            QuestObjectView characterView = collision.GetComponent<QuestObjectView>();
            OnLevelObjectContact?.Invoke(characterView);
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
