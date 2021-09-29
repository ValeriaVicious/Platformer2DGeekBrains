using UnityEngine;


namespace PlatformerGeekBrains
{
    public class PatrolEnemyView : MonoBehaviour
    {

        #region Fields

        public Transform EnemyTransform;
        public SpriteRenderer EnemySprite;
        public Collider2D EnemyCollider;
        public Rigidbody2D EnemyRigidbody;

        #endregion


        #region UnityMethods

        private void Start()
        {
            EnemyTransform = GetComponent<Transform>();
            EnemySprite = GetComponent<SpriteRenderer>();
            EnemyRigidbody = GetComponent<Rigidbody2D>();
            EnemyCollider = GetComponent<Collider2D>();
        }

        #endregion
    }
}