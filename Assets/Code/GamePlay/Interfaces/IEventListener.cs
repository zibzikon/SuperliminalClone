using Entitas;

namespace Code.GamePlay.Interfaces
{
    public interface IEventListener
    {
        void Register(GameEntity entity);
        void Unregister(GameEntity entity);
    }
}