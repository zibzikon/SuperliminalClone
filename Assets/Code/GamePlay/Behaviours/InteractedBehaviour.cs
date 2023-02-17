using Code.Game.Behaviours;
using UnityEngine;

namespace Code.GamePlay.Behaviours
{
    public class InteractedBehaviour : EntityBehaviour
    {
        [SerializeField] private bool _interact;
        
        private void OnValidate()
        {
            if (!_interact) return;
            
            Entity.isInteracted = true;
            _interact = false;
        }
    }
}