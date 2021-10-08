using UnityEngine;


namespace PlatformerGeekBrains
{
    [CreateAssetMenu(fileName = nameof(QuestConfig), menuName = "Configs/" + nameof(QuestConfig), order = 1)]
    public sealed class QuestConfig : ScriptableObject
    {
        #region Fields

        public int ID;
        public QuestType QuestType;

        #endregion
    }
}
