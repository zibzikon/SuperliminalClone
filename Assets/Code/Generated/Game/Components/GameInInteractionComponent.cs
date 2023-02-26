//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Code.GamePlay.Components.InInteraction inInteractionComponent = new Code.GamePlay.Components.InInteraction();

    public bool isInInteraction {
        get { return HasComponent(GameComponentsLookup.InInteraction); }
        set {
            if (value != isInInteraction) {
                var index = GameComponentsLookup.InInteraction;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : inInteractionComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherInInteraction;

    public static Entitas.IMatcher<GameEntity> InInteraction {
        get {
            if (_matcherInInteraction == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InInteraction);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInInteraction = matcher;
            }

            return _matcherInInteraction;
        }
    }
}