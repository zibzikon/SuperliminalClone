namespace Code.StateMachine.Interfaces
{
    public interface IGameStateMachine
    {
        void SwitchState<T>() where T : IGameState;
    }
}