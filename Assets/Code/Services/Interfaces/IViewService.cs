using Code.Infrastructure.Interfaces;
using UnityEngine;

namespace Code.Services.Interfaces
{
    public interface IViewService : ICleanup
    {
        T CreateView<T> (T viewPrefab) where T : Object;
        T CreateUI<T> (T uiPrefab) where T : Object;
    }
}