namespace Code.Interfaces
{
    public interface IGameStateMachine
    {
        void SwitchState<T>() where T : IGameState;
    }
}