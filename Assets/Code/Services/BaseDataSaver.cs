using System.IO;
using System.Threading.Tasks;

public class BaseDataSaver<T> : IDataSaver<T>
{
    private T _data;
    private readonly string _savingPath;
    private readonly IDataSerializer _serializer;

    public BaseDataSaver(T data, string savingPath, IDataSerializer serializer)
    {
        _data = data;
        _savingPath = savingPath;
        _serializer = serializer;
    }
    
    
    public void UpdateData(T data)
        => _data = data;

    public void UpdateData(object data)
        => _data = (T)data;
    
    public async Task SaveAsync()
    {
        var serialized = _serializer.Serialize(_data);
        await using var stream = new FileStream(_savingPath, FileMode.OpenOrCreate);
        await using var writer = new StreamWriter(stream);
        
        await writer.WriteAsync(serialized);
    }
}