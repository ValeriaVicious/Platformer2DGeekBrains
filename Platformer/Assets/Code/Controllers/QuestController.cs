using System;


namespace PlatformerGeekBrains.Quests
{
    public sealed class QuestController : IQuest
    {
        #region Fields

        private QuestObjectView _view;
        private IQuestModel _model;
        private bool _isActive;
        public event EventHandler<IQuest> Completed;

        #endregion


        #region Properties

        public bool IsCompleted { get; private set; }

        #endregion


        #region ClassLifeCycles

        public QuestController(QuestObjectView view, IQuestModel questModel)
        {
            _view = view;
            _model = questModel;
        }

        #endregion


        #region Methods

        private void OnContact(QuestObjectView view)
        {
            bool isCompleted = _model.TryComplete(view.gameObject);
            if (isCompleted)
            {
                Complete();
            }
        }

        private void Complete()
        {
            if (!_isActive)
            {
                return;
            }
            _isActive = false;
            _view.OnLevelObjectContact -= OnContact;
            _view.Complete();
            OnComplited();
        }

        private void OnComplited()
        {
            Completed?.Invoke(this, this);
        }

        public void Dispose()
        {
            _view.OnLevelObjectContact -= OnContact;
        }

        public void Reset()
        {
          if (_isActive)
            {
                return;
            }
            _isActive = true;
            _view.OnLevelObjectContact += OnContact;
            _view.Activate();
        }

        #endregion
    }
}
