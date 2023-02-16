using System.Collections.Generic;
using System.Linq;
using Code.Data;
using Code.Data.ResourcesData.Enums;
using Code.Game.Interfaces;

namespace Code.Game
{
    public class Game : IGame
    {
        public Dictionary<int, LevelData> Levels { get; }

        public LevelData LastUnlockedLevel { get; }
        
        public Game(IEnumerable<LevelData> levels)
        {
            Levels = levels.ToDictionary(x => x.Index);
            
            LastUnlockedLevel =
                Levels[Levels
                    .Where(x => x.Value.State == LevelState.Unlocked)
                    .Select(x => x.Value.Index)
                    .Max()];
        }
    }
}