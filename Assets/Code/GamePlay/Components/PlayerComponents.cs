using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code.GamePlay.Components
{
    [Game] public class Player : IComponent { }
    [Game] public class CharacterController : IComponent { public UnityEngine.CharacterController Value; }
    [Game] public class PlayerCamera : IComponent { }
    
    [Game] public class SuperliminalScalable : IComponent { }
    
    [Game] public class GravityForce : IComponent { public float Value; }   
    [Game] public class MoveSpeed : IComponent { public float Value; }
    [Game] public class MoveDirection : IComponent { public Vector3 Value; }
    [Game] public class LookSpeed : IComponent { public float Value; }
    [Game] public class JumpForce : IComponent { public float Value; }
    [Game] public class LookXLimit : IComponent { public float Value; }    
    [Input] public class PlayerMotion : IComponent { public Vector2 Value; }
    [Input] public class PlayerJump : IComponent { }
    
    
    [Input, Event(Self)] public class PlayerInteract : IComponent { }
    [Game, Event(Self)] public class Grounded : IComponent { }
}