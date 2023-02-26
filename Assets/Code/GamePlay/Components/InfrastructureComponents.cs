using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;
using static Entitas.CodeGeneration.Attributes.EventType;

namespace Code.GamePlay.Components
{
    [Game] public class Door : IComponent { }
    [Game] public class PressurePlate : IComponent { }
    [Game] public class Interactable : IComponent { }
    [Game] public class Selectable : IComponent { }

    
    [Game] public class PhysicalObject : IComponent { }
    [Game] public class Collisionable : IComponent { }
    [Game] public class Interactor : IComponent { }
    [Game] public class InInteraction : IComponent { }
    [Game] public class Selector : IComponent { }

    
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    [Game] public class ConnectedEntity : IComponent { public GameEntity Value; }
    [Game] public class CollidedEntity : IComponent { public GameEntity Value; }
    [Game] public class Transform : IComponent { public UnityEngine.Transform Value; }
    
    
    [Unique, Input] public class Keyboard : IComponent { }
    [Unique, Input] public class Mouse : IComponent { }
    
    
    [Input] public class MouseAxis : IComponent { public Vector3 Value; }
    [Input] public class LeftMouse : IComponent {  }
    [Input] public class RightMouse : IComponent {  }
    
    
    [Game] public class LastUpdatedPosition : IComponent { public Vector3 Value; }
    [Game, Event(Self)] public class Rotation : IComponent { public Vector3 Value; }
    [Game, Event(Self)] public class Scale : IComponent { public Vector3 Value; }
    [Game, Event(Self)] public class Position : IComponent { public Vector3 Value; }
    [Game, Event(Self)] public class RigidbodyForce : IComponent { public Vector3 Value; }
    [Game, Event(Self)] public class RigidbodyVelocity : IComponent { public Vector3 Value; }
    [Game, Event(Self), Event(Self, Removed)] public class Interacted : IComponent { }
    [Game, Event(Self), Event(Self, Removed)] public class CollidersDisabled : IComponent { }
    [Game, Event(Self), Event(Self, Removed)] public class Selected : IComponent { }
    [Game, Event(Self), Event(Self, Removed)] public class Kinematic : IComponent { }
    [Game, Event(Self)] public class Collided : IComponent { }
}
