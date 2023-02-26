//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.GamePlay.Components.CollidersDisabled collidersDisabledComponent = new Code.GamePlay.Components.CollidersDisabled();

    public bool isCollidersDisabled {
        get { return HasComponent(GameComponentsLookup.CollidersDisabled); }
        set {
            if (value != isCollidersDisabled) {
                var index = GameComponentsLookup.CollidersDisabled;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : collidersDisabledComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherCollidersDisabled;

    public static Entitas.IMatcher<GameEntity> CollidersDisabled {
        get {
            if (_matcherCollidersDisabled == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CollidersDisabled);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollidersDisabled = matcher;
            }

            return _matcherCollidersDisabled;
        }
    }
}