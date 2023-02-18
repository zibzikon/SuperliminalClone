//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Collided = 0;
    public const int CollisionID = 1;
    public const int ConnectedEntity = 2;
    public const int Door = 3;
    public const int Id = 4;
    public const int Interaction = 5;
    public const int PressurePlate = 6;
    public const int InteractionListener = 7;

    public const int TotalComponents = 8;

    public static readonly string[] componentNames = {
        "Collided",
        "CollisionID",
        "ConnectedEntity",
        "Door",
        "Id",
        "Interaction",
        "PressurePlate",
        "InteractionListener"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.GamePlay.Components.Collided),
        typeof(Code.GamePlay.Components.CollisionID),
        typeof(Code.GamePlay.Components.ConnectedEntity),
        typeof(Code.GamePlay.Components.Door),
        typeof(Code.GamePlay.Components.Id),
        typeof(Code.GamePlay.Components.Interaction),
        typeof(Code.GamePlay.Components.PressurePlate),
        typeof(InteractionListenerComponent)
    };
}
