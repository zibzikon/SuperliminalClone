using Code.Data;
using UnityEngine;

namespace Code.Factories.Interfaces.UI
{
    public interface ILevelPreviewFactory
    {
        Sprite Get(LevelData levelData);
    }
}