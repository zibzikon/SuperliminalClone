using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Services.Interfaces;

namespace Code.Services
{
    public class GameDataSaver : IGameDataSaver
    {
        private readonly IEnumerable<IDataSaver> _dataSavers;

        public GameDataSaver(IEnumerable<IDataSaver> dataSavers)
        {
            _dataSavers = dataSavers;
        }

        public async Task SaveAsync()
        {
            foreach (var dataSaver in _dataSavers)
                await dataSaver.SaveAsync();
        }

    }
}