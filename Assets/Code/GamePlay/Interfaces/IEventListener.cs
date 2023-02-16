using Entitas;

namespace Code.Game.Interfaces
{
    public interface IEventListener
    {
        void Register(IEntity entity);
        void Unregister(IEntity entity);
    }
}