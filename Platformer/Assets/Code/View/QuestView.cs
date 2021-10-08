using UnityEngine;


namespace PlatformerGeekBrains.Quests
{
    public sealed class QuestView : MonoBehaviour
    {
        #region Fields

        public QuestObjectView SingleQuest;
        public QuestStoryConfig[] QuestStoryConfigs;
        public QuestObjectView[] GetQuestObjectViews;

        #endregion
    }
}
