using Entitas;

namespace Code.GamePlay.Systems.Input
{
    public class RegisterInputsSystem : IInitializeSystem
    {
        private readonly InputContext _input;

        public RegisterInputsSystem(InputContext input) => _input = input;

        public void Initialize()
        {
            _input.isKeyboard = true;
            _input.isMouse = true;
        }
    }
}