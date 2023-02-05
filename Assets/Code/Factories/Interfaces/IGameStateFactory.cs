namespace Code.Interfaces
{
    public interface IGameStateFactory
    {
        T Get<T>() where T : IGameState;
    }
}