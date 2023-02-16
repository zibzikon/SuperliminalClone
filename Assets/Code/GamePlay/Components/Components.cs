using Code.Game.Interfaces;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Game.Components
{
    [Game]
    public class Door : IComponent { }

    [Game]
    public class PressurePlate : IComponent { }

    public class Interactable : IComponent { }

    [Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
    public class Interacted : IComponent { }
    
    public class ViewComponent : IComponent { public GameObject Value; }
    public class ViewControllerComponent : IComponent { public IViewController Value; }

    public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    public class ConnectedEntityID : IComponent { [EntityIndex] public int Value; }
}
