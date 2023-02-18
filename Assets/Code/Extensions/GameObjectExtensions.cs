using Code.Game.Interfaces;
using Code.GamePlay.Interfaces;
using UnityEngine;

namespace Code.Extensions
{
    public static class GameObjectExtensions
    {
        public static bool MatchLayer(this Component component, LayerMask layerMask) =>
            component.gameObject.MatchLayer(layerMask);
        
        public static bool MatchLayer (this GameObject gameObject, LayerMask layerMask) =>    
            ((1 << gameObject.layer) & layerMask) != 0;

    }
}