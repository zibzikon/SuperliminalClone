using Entitas;
using Entitas.CodeGeneration.Attributes;
using static Entitas.CodeGeneration.Attributes.EventTarget;

namespace Code.GamePlay.Components
{
    [Game] public class Door : IComponent { }

    [Game] public class PressurePlate : IComponent { }

    [Game] public class Collided : IComponent { }
    
    [Game] public class ConnectedEntity : IComponent { public GameEntity Value; }

    [Game] public class CollisionID : IComponent { [EntityIndex] public int Value; }
    
    public class Id : IComponent { [PrimaryEntityIndex] public int Value; }
    
    [Game, Event(Self)] public class Interaction : IComponent { public bool Interacted; }

}
