using System.Threading.Tasks;

namespace Code.Domain.Visualisation
{
    public interface ISceneTransition
    {
        Task EnterTransitionAsync();
        Task ExitTransitionAsync();
        
        void SetProgress(int progress);
    }
}