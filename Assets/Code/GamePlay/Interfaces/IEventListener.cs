using Entitas;

namespace Code.GamePlay.Interfaces
{
    public interface IEventListener
    {
        void Register(IEntity entity);
        void Unregister(IEntity entity);
    }
}