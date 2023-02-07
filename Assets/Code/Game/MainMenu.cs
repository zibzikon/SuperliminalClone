using Code.Domain.Mediators;
using UnityEngine;

namespace Code.Domain
{
    public class MainMenu : MonoBehaviour, IMainMenu
    {
        [field: SerializeField] public MainMediator Mediator { get; private set;}
    }
}