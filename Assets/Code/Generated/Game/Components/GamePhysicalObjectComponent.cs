//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.GamePlay.Components.PhysicalObject physicalObjectComponent = new Code.GamePlay.Components.PhysicalObject();

    public bool isPhysicalObject {
        get { return HasComponent(GameComponentsLookup.PhysicalObject); }
        set {
            if (value != isPhysicalObject) {
                var index = GameComponentsLookup.PhysicalObject;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : physicalObjectComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPhysicalObject;

    public static Entitas.IMatcher<GameEntity> PhysicalObject {
        get {
            if (_matcherPhysicalObject == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PhysicalObject);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPhysicalObject = matcher;
            }

            return _matcherPhysicalObject;
        }
    }
}
