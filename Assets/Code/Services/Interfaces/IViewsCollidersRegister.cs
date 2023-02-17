using Code.Infrastructure;

namespace Code.Services.Interfaces
{
    public interface IViewsCollidersRegister
    {
        void Register(int key, ViewCollider value);
        ViewCollider Take(int key);
    }
}