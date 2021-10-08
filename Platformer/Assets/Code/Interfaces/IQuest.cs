using System;


namespace PlatformerGeekBrains.Quests
{
    public interface IQuest : IDisposable
    {
        public event EventHandler<IQuest> Completed;
        public bool IsCompleted { get; }
        public void Reset();
    }
}
