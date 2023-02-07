using Code.Domain.Mediators;

namespace Code.Domain
{
    public interface IMainMenu
    {
        MainMediator Mediator { get; }
    }
}