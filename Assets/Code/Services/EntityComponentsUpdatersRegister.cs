using System.Collections.Generic;
using System.Linq;
using Code.GamePlay.Unity;
using Code.Infrastructure.Interfaces;

namespace Code.Services
{
    public class EntityComponentsUpdatersRegister : IEntityComponentsUpdatersRegister
    {
        private Dictionary<IEntityComponentUpdater, GameEntity> _updaters = new ();

        public void Register(IEntityComponentUpdater updater, GameEntity entity)
            => _updaters.Add(updater, entity);
        

        public void Unregister(IEntityComponentUpdater updater)
            => _updaters.Remove(updater);


        public IEnumerable<(IEntityComponentUpdater, GameEntity)> GetUpdaters()
            => _updaters.Select(x => (x.Key, x.Value));
        
    }
}