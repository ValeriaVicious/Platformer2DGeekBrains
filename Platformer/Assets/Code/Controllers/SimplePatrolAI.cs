using System;
using UnityEngine;


namespace PlatformerGeekBrains
{
    public sealed class SimplePatrolAI
    {
        #region Fields

        private readonly PatrolEnemyView _view;
        private readonly SimplePatrolAIModel _model;

        #endregion


        #region ClassLifeCycles

        public SimplePatrolAI(PatrolEnemyView view, SimplePatrolAIModel model)
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
        }

        #endregion


        #region Methods

        public void FixedUpdate(float deltaTime)
        {
            var newVelocity = _model.CalculateVelocity(_view.EnemyTransform.position) * deltaTime;
            _view.EnemyRigidbody.velocity = newVelocity;
        }

        #endregion
    }
}
