using UnityEngine;
using System.Collections.Generic;
using Pathfinding;


namespace PlatformerGeekBrains
{
    public sealed class EnemiesConfiguration : MonoBehaviour
    {
        #region Fields

        [SerializeField] private AIEnemyConfig _simplePatrolAIConfig;
        [SerializeField] private PatrolEnemyView _patrolEnemyView;

        private SimplePatrolAI _simplePatrolAI;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _simplePatrolAI = new SimplePatrolAI(_patrolEnemyView,
                 new SimplePatrolAIModel(_simplePatrolAIConfig, _simplePatrolAIConfig.Waypoints));
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.fixedDeltaTime;
            if(_simplePatrolAI != null)
            {
                _simplePatrolAI.FixedUpdate(deltaTime);
            }
        }

        #endregion
    }
}
