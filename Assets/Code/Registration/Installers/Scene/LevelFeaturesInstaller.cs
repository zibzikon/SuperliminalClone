using Code.GamePlay.SystemsRegistration;
using Zenject;

namespace Code.Registration.Installers.Scene
{
    public class LevelFeaturesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var contexts = Contexts.sharedInstance;
            
            Container.BindInstance(contexts);
            Container.BindInstance(contexts.game);
            Container.BindInstance(contexts.input);

            Container.Bind<FullGameFeature>().AsSingle();
        }
    }
}