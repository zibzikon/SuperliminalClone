using System.Threading.Tasks;

namespace Code.Visualisation.Interfaces
{
    public interface ISceneTransition
    {
        Task EnterTransitionAsync();
        Task ExitTransitionAsync();
        
        void SetProgress(int progress);
    }
}