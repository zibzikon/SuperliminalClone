using System.Collections.Generic;
using Code.Data;
using Code.Services;

namespace Code.Game.Interfaces
{
    public interface IGame
    { 
        Dictionary<int, LevelData> Levels { get; }
        ControlActions ControlActions { get; }
        LevelData LastUnlockedLevel { get; }
    }
}