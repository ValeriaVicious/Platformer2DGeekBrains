using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


namespace PlatformerGeekBrains.Quests
{
    public sealed class QuestConfigurationController
    {
        #region Fields

        private QuestObjectView _singleQuestView;
        private QuestController _singleQuest;
        private QuestStoryConfig[] _questStoryConfigs;
        private QuestObjectView[] _questObjectViews;
        private List<IQuestStory> _questStories;
        private Dictionary<QuestType, Func<IQuestModel>> _questFactories = new Dictionary<QuestType, Func<IQuestModel>>(1);
        private Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories = new Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>(2);

        #endregion


        #region ClassLifeCycles

        public QuestConfigurationController(QuestView questView)
        {
            _questObjectViews = questView.GetQuestObjectViews;
            _questStoryConfigs = questView.QuestStoryConfigs;
            _singleQuestView = questView.SingleQuest;
        }

        #endregion


        #region Methods

        public void Start()
        {
            _singleQuest = new QuestController(_singleQuestView, new CoinQuestModel());
            _singleQuest.Reset();
        }

        #endregion
    }
}
