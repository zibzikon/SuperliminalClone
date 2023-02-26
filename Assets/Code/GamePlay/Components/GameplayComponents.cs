using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code.GamePlay.Components
{
    [Game] public class Player : IComponent { }
    [Game] public class Camera : IComponent { }
    [Game] public class ForcedPerspectiveObject : IComponent { }
    
    
    [Game] public class ObjectBounds : IComponent { public Bounds Value; }
    [Game] public class MaxInteractionDistance : IComponent { public float Value; }
    [Game] public class SelectionDistance : IComponent { public float Value; }
    [Game] public class OriginalScale : IComponent { public float Value; }
    [Game] public class SelectedObject : IComponent { public GameEntity Value; }
    [Game] public class MoveSpeed : IComponent { public float Value; }
    [Game] public class LookSpeed : IComponent { public float Value; }
    [Game] public class ConnectedCamera : IComponent { public GameEntity Value; }
    [Game] public class JumpForce : IComponent { public float Value; }
    [Game] public class LookXLimit : IComponent { public float Value; }    
    
    
    [Input] public class PlayerMotion : IComponent { public Vector2 Value; }
    [Input] public class PlayerJump : IComponent { }
    
    
    [Input, Event(Self)] public class PlayerInteract : IComponent { }
    [Game, Event(Self)] public class Grounded : IComponent { }
}