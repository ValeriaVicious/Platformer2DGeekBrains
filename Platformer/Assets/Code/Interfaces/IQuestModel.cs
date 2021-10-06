using UnityEngine;


namespace PlatformerGeekBrains.Quests
{
    public interface IQuestModel
    {
        public bool TryComplete(GameObject player);
    }
}
