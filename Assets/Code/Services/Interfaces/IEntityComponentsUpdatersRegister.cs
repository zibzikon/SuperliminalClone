using System.Collections.Generic;
using Code.GamePlay.Unity;

namespace Code.Infrastructure.Interfaces
{
    public interface IEntityComponentsUpdatersRegister
    {
        void Register(IEntityComponentUpdater updater, GameEntity entity);
        void Unregister(IEntityComponentUpdater updater);
        
        IEnumerable<(IEntityComponentUpdater, GameEntity)> GetUpdaters();
    }
}