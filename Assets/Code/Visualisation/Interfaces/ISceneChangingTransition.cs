using System.Threading.Tasks;

namespace Code.Domain.Visualisation
{
    public interface ISceneChangingTransition
    {
        Task EnterTransitionAsync();
        Task ExitTransitionAsync();
        
        void SetProgress(int progress);
    }
}