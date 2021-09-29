﻿using System;
using UnityEngine;


namespace PlatformerGeekBrains
{
    [Serializable]
   public struct AIEnemyConfig
    {
        #region Fields

        public float Speed;
        public float MinSqrDistanceToTarget;
        public Transform[] Waypoints;

        #endregion
    }
}