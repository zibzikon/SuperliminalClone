//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly Code.GamePlay.Components.PlayerInteract playerInteractComponent = new Code.GamePlay.Components.PlayerInteract();

    public bool isPlayerInteract {
        get { return HasComponent(InputComponentsLookup.PlayerInteract); }
        set {
            if (value != isPlayerInteract) {
                var index = InputComponentsLookup.PlayerInteract;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : playerInteractComponent;

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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherPlayerInteract;

    public static Entitas.IMatcher<InputEntity> PlayerInteract {
        get {
            if (_matcherPlayerInteract == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.PlayerInteract);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherPlayerInteract = matcher;
            }

            return _matcherPlayerInteract;
        }
    }
}