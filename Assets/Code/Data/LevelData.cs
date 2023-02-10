using Code.Data.ResourcesData.Enums;

namespace Code.Data
{
    public struct LevelData
    {
        public readonly int Index;
        public LevelState State { get; set; }

        public LevelData(int index, LevelState state)
        {
            Index = index;
            State = state;
        }
        
    }
}