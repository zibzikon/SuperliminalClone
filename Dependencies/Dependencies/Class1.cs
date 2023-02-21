using System.Collections.Generic;
using System.IO;

namespace Dependencies
{
   public class ControlActions : IControlActions
{
    private Dictionary<KeyCode, ControlActionType> _actions;
    private Dictionary<ControlActionType, KeyCode> _keyCodes;

    public ControlActions(ControlAction[] actions)
    {
        _actions = actions.ToDictionary(x => x.KeyCode, x => x.ActionType);
        _keyCodes = actions.ToDictionary(x => x.ActionType, x => x.KeyCode);
    }

    public ControlActionType GetAction(KeyCode keyCode)
        => _actions[keyCode];

    public KeyCode GetKeyCode(ControlActionType actionType)
        => _keyCodes[actionType];
}

public interface IControlActions
{
    ControlActionType GetAction(KeyCode keyCode);
    KeyCode GetKeyCode(ControlActionType actionType);
}

public struct ControlAction
{
    public KeyCode KeyCode;
    public ControlActionType ActionType;

    public ControlAction(KeyCode keyCode, ControlActionType actionType)
    {
        KeyCode = keyCode;
        ActionType = actionType;
    }
}

public class JsonDataSerializer : IDataSerializer
{
    public string Serialize<T>(T obj) 
        => JsonUtility.ToJson(obj);


    public T Deserialize<T>(string token)
        => JsonUtility.FromJson<T>(token);
}

public interface IDataSerializer
{
    string Serialize<T>(T obj);
    T Deserialize<T>(string token);
}

public class GameDataSaver : IGameDataSaver
{
    private readonly IEnumerable<IDataSaver> _dataSavers;

    public GameDataSaver(IEnumerable<IDataSaver> dataSavers)
    {
        _dataSavers = dataSavers;
    }

    public async Task SaveAsync()
    {
        foreach (var dataSaver in _dataSavers)
            await dataSaver.SaveAsync();
    }

}

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

public interface IGameDataSaver
{
    Task SaveAsync();
}

public interface IDataSaver<T> : IDataSaver
{
    void UpdateData(T data);
}

public interface IDataSaver
{
    void UpdateData(object data);
    Task SaveAsync();
}

public interface GameDataLoader
{
    
}

//ControlActions(IEnumerable<ControlAction> actions)
//ControlAction(KeyCode key, ActionType action)
//ControlActionsSerializer()
//DataSaver(string dataRootPath)
//

public enum ControlActionType
{
    None,
    
    PlayerMoveFowards,
    PlayerMoveBackwards,
    PlayerMoveLeft,
    PlayerMoveRight,
}