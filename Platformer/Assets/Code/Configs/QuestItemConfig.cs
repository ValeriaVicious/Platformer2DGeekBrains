using System.Collections.Generic;
using UnityEngine;


namespace PlatformerGeekBrains
{
    [CreateAssetMenu(fileName = nameof(QuestItemConfig), menuName = "Configs/" + nameof(QuestItemConfig), order = 1)]
    public sealed class QuestItemConfig : ScriptableObject
    {
        #region Fields

        public int QuestID;
        public List<int> QuestItemIDCollection;

        #endregion
    }
}