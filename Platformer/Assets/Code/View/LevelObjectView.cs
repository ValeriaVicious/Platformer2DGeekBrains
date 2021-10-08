using UnityEngine;
using System;


namespace PlatformerGeekBrains.Quests
{
    public class LevelObjectView : MonoBehaviour
    {
        #region Fields

        private LevelObjectView _levelObjectView;
        public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        #endregion


        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _levelObjectView = collision.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(_levelObjectView);
        }

        #endregion

    }
}
