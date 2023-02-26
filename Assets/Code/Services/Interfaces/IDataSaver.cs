using System.Threading.Tasks;

namespace Code.Services.Interfaces
{
    public interface IDataSaver
    {
        void UpdateData(object data);
        Task SaveAsync();
    }

    public interface IDataSaver<T> : IDataSaver
    {
        void UpdateData(T data);
    }
}