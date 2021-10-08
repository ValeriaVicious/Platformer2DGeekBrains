using UnityEngine;


namespace PlatformerGeekBrains
{
    [CreateAssetMenu(fileName = nameof(QuestStoryConfig), menuName = "Configs/" + nameof(QuestStoryConfig), order = 1)]
    public sealed class QuestStoryConfig : ScriptableObject
    {
        #region Fields

        public QuestConfig[] QuestConfigs;
        public QuestStoryType QuestStoryType;

        #endregion
    }
}