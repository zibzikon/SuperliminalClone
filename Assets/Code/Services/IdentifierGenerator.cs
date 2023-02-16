using Code.Services.Interfaces;

namespace Code.Services
{
    public class IdentifierGenerator : IIdentifierGenerator
    {
        private int _lastIdentifier = -1;
        
        public int GetNext() 
            => _lastIdentifier += 1;
        
    }
}