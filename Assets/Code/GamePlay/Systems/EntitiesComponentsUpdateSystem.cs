using Code.Infrastructure.Interfaces;
using Entitas;

namespace Code.GamePlay.Systems
{
    public class EntitiesComponentsUpdateSystem : IExecuteSystem
    {
        private readonly IEntityComponentsUpdatersRegister _updatersRegister;

        public EntitiesComponentsUpdateSystem(IEntityComponentsUpdatersRegister updatersRegister)
        {
            _updatersRegister = updatersRegister;
        }
        
        public void Execute()
        {
            foreach (var (updater, entity) in _updatersRegister.GetUpdaters())
            {
                updater.OnUpdate(entity);
            }
        }
    }
}