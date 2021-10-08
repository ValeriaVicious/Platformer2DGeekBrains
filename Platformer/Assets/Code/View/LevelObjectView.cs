using UnityEngine;
using System;


namespace PlatformerGeekBrains.Quests
{
    public class LevelObjectView : MonoBehaviour
    {
        #region Fields

        public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        #endregion


        #region UnityMethods

        private void OnTriggerEnter2D(Collider2D collision)
        {
            LevelObjectView levelObjectView = collision.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(levelObjectView);
        }

        #endregion

    }
}
