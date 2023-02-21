using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code.GamePlay.Components
{
    [Game] public class Door : IComponent { }
    [Game] public class PressurePlate : IComponent { }
    [Game] public class Player : IComponent { }
    [Game] public class PlayerCamera : IComponent { }

    
    [Game] public class Collided : IComponent { }
    [Game] public class Grounded : IComponent { }
    
    
    [Game] public class CollisionID : IComponent { [EntityIndex] public int Value; }
    [Game] public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    [Game] public class ConnectedEntity : IComponent { public GameEntity Value; }
    [Game] public class JumpCurve : IComponent { public AnimationCurve Value; }   
    [Game] public class MoveSpeed : IComponent { public float Value; }
    [Game] public class LookSpeed : IComponent { public float Value; }
    [Game] public class LookXLimit : IComponent { public float Value; }
    [Game] public class Transform : IComponent { public UnityEngine.Transform Value; }
    
    
    [Input] public class PlayerMove : IComponent { public Vector2 Value; }
    [Input] public class MouseAxis : IComponent { public Vector3 Value; }
    [Input] public class Jump : IComponent { }

    
    [Unique, Input] public class Keyboard : IComponent { }
    [Unique, Input] public class Mouse : IComponent { }


    [Game, Event(Self)] public class Rotation : IComponent { public Vector3 Value; }
    [Game, Event(Self)] public class Position : IComponent { public Vector3 Value; }
    [Game, Event(Self)] public class Interaction : IComponent { public bool Interacted; }
}
