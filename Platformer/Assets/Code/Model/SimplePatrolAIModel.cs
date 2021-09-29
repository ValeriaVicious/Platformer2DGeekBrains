using UnityEngine;


namespace PlatformerGeekBrains
{
    public sealed class SimplePatrolAIModel
    {
        #region Fields

        private readonly AIEnemyConfig _config;
        private Transform _target;
        private int _currentPointIndex;

        #endregion


        #region ClassLifeCycles

        public SimplePatrolAIModel(AIEnemyConfig config, Transform[] waypoints)
        {
            _config = config;
            _target = GetNextTarget();
            _currentPointIndex = waypoints.Length;
        }

        #endregion


        #region Methods

        public Transform GetNextTarget()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _config.Waypoints.Length;
            return _config.Waypoints[_currentPointIndex];
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= _config.MinSqrDistanceToTarget)
            {
                _target = GetNextTarget();
            }

            var direction = ((Vector2)_target.position - fromPosition).normalized;
            return _config.Speed * direction;
        }

        #endregion
    }
}
