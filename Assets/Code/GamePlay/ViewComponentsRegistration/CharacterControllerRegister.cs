using Code.GamePlay.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.GamePlay.ViewComponentsRegistration
{
    public class CharacterControllerRegister : MonoBehaviour, IViewComponentRegister
    {
        [Required, SerializeField] private CharacterController _characterController;

        public void Register(GameEntity entity)
            => entity.AddCharacterController(_characterController);
    }
}