using Code.StateMachine.Interfaces;

namespace Code.Factories.Interfaces
{
    public interface IGameStateFactory
    {
        T Get<T>() where T : IGameState;
    }
}