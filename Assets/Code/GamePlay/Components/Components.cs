using Code.GamePlay.Interfaces;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code.GamePlay.Components
{
    [Game]
    public class Door : IComponent { }

    [Game]
    public class PressurePlate : IComponent { }

    public class Interactable : IComponent { }
    
    public class ViewComponent : IComponent { public GameObject Value; }
    public class ViewControllerComponent : IComponent { public IViewController Value; }

    public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    public class ConnectedEntityID : IComponent { [EntityIndex] public int Value; }
    
    [Game, Event(Self)] public class Interacted : IComponent { }
}
