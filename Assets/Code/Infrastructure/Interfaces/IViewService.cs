using UnityEngine;

namespace Code.Infrastructure.Interfaces
{
    public interface IViewService : ICleanup
    {
        T CreateView<T> (T viewPrefab) where T : Object;
        T CreateUI<T> (T uiPrefab) where T : Object;
    }
}