using System.Threading.Tasks;
using Code.Data;
using UnityEngine;

namespace Code.Infrastructure.Interfaces
{
    public interface ILevelLoader
    {
        public AsyncOperation LevelLoadingAsyncOperation { get; }
        Task LoadAsync(LevelData levelData);
    }
} 