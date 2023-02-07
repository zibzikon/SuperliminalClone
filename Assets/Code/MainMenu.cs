using Code.Domain.Mediators;
using UnityEngine;

namespace Code.Domain
{
    public class MainMenu : MonoBehaviour, IMainMenu
    {
        public MainMediator Mediator { get; }
    }

    public interface IMainMenu
    {
        MainMediator Mediator { get; }
    }
}