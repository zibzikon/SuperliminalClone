using Code.GamePlay.Interfaces;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code.GamePlay.Components
{
    [Game] public class Door : IComponent { }

    [Game] public class PressurePlate : IComponent { }

    [Game] public class Interactable : IComponent { }
    [Game] public class Collided : IComponent { }

    [Game] public class ViewComponent : IComponent { public GameObject Value; }
    [Game] public class ViewControllerComponent : IComponent { public IViewController Value; }
    [Game] public class ConnectedEntity : IComponent { public GameEntity Value; }

    [Game] public class CollisionID : IComponent { [EntityIndex] public int Value; }
    
    public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    
    [Game, Event(Self)] public class Interacting : IComponent { }
}
