namespace Code.Services.Interfaces
{
    public interface IDataSerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string token);
    }
}