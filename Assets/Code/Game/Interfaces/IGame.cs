using System.Collections.Generic;
using Code.Data;

namespace Code.Game.Interfaces
{
    public interface IGame
    { 
        Dictionary<int, LevelData> Levels { get; }
        LevelData LastUnlockedLevel { get; }
    }
}