using UnityEngine;


namespace PlatformerGeekBrains
{
    public sealed class SimplePatrolAIModel
    {
        #region Fields

        private readonly Transform[] _wayPoints;
        private int _currentPointIndex;

        #endregion


        #region ClassLifeCycles

        public SimplePatrolAIModel(Transform[] wayPoints)
        {
            _wayPoints = wayPoints;
            _currentPointIndex = 0;
        }

        #endregion


        #region Methods

        public Transform GetNextTarget()
        {
            if (_wayPoints == null)
            {
                return null;
            }
            _currentPointIndex = (_currentPointIndex + 1) % _wayPoints.Length;
            return _wayPoints[_currentPointIndex];
        }

        public Transform GetTheClosestTarget(Vector2 fromPosition)
        {
            if (_wayPoints == null)
            {
                return null;
            }

            var closestTargetIndex = 0;
            var closestDistance = 0.0f;

            for (int i = 0; i < _wayPoints.Length; i++)
            {
                var distance = Vector2.Distance(fromPosition, _wayPoints[i].position);
                if (closestDistance > distance)
                {
                    closestDistance = distance;
                    closestDistance = i;
                }
            }
            _currentPointIndex = closestTargetIndex;
            return _wayPoints[_currentPointIndex];
        }

        #endregion
    }
}
