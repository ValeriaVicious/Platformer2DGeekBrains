﻿using System;
using System.Collections.Generic;
using UnityEngine;


namespace PlatformerGeekBrains
{
    [CreateAssetMenu(fileName = nameof(SpriteCharacterAnimationConfig), menuName = "Configs/" + nameof(SpriteCharacterAnimationConfig), order = 1)]
    public sealed class SpriteCharacterAnimationConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpritesSequence
        {
            #region Fields

            public Track Track;
            public List<Sprite> Sprites = new List<Sprite>();

            #endregion
        }

        #region Fields

        public List<SpritesSequence> Sequences = new List<SpritesSequence>();

        #endregion
    }
}
