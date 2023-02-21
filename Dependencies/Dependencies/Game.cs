using System;
using System.Collections.Generic;
using System.Linq;
using Code.Data;
using Code.Game.Interfaces;
using Dependencies;

namespace Code.Game
{
    [Serializable]
    public class Game : IGame
    {
        private readonly ControlActions _controlActions;

        public Dictionary<int, LevelData> Levels { get; }

        public ControlActions ControlActions { get; }
        public LevelData LastUnlockedLevel { get; }
        
        public Game(IEnumerable<LevelData> levels, ControlActions controlActions)
        {
            Levels = levels.ToDictionary(x => x.Index);
            
            LastUnlockedLevel =
                Levels[Levels
                    .Where(x => x.Value.State == LevelState.Unlocked)
                    .Select(x => x.Value.Index)
                    .Max()];
            
            _controlActions = controlActions;
        }
    }
}