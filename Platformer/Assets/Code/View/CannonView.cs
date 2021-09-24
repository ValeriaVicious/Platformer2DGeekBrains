using System.Collections.Generic;
using UnityEngine;


namespace PlatformerGeekBrains
{
    public sealed class CannonView : MonoBehaviour
    {
        #region Fields

        public Transform MuzzleTransform;
        public Transform EmmiterTransform;
        public List<BulletView> Bullets;

        #endregion
    }
}