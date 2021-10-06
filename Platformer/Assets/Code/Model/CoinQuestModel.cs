using UnityEngine;


namespace PlatformerGeekBrains.Quests
{
    public sealed class CoinQuestModel : IQuestModel
    {
        #region Methods

        public bool TryComplete(GameObject player)
        {
            return player.CompareTag(Constants.PlayerTag);
        }

        #endregion
    }
}
