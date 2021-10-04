using UnityEngine;


namespace PlatformerGeekBrains
{
    [CreateAssetMenu(fileName = nameof(QuestStory), menuName = "Configs/" + nameof(QuestStory), order = 1)]
    public sealed class QuestStory : ScriptableObject
    {
        #region Fields

        public QuestConfig[] QuestConfigs;
        public QuestStoryType QuestStoryType;

        #endregion
    }
}