using Entitas;

namespace Code.Game.Interfaces
{
    public interface IViewController
    {
        GameEntity Entity { get; }
        void Initialize(GameEntity entity, GameContext context);
        void Destroy();
    }
}