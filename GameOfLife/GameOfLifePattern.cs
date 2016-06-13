using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{

    /// <summary>
    /// Game Of Life Ready made Patterns
    /// </summary>
    public class PatternFactory
    {
        public enum Pattern { Blinker, Smiley, DieHard };

        public static IGameOfLifePattern CreatePattern(Pattern pattern)
        {
            IGameOfLifePattern golPattern = null;

            switch (pattern)
            {
                case Pattern.Blinker:
                    golPattern = new BlinkerPattern();
                    break;
                case Pattern.Smiley:
                    golPattern = new SmileyPattern();
                    break;
                case Pattern.DieHard:
                    golPattern = new DieHardPattern();
                    break;
                default:
                    golPattern = new DieHardPattern();
                    break;

            }

            return golPattern;
        }
    }

    public interface IGameOfLifePattern
    {
        void AssignPattern(GOLGrid gameGrid);
    }

    public class BlinkerPattern : IGameOfLifePattern
    {
        public void AssignPattern(GOLGrid gameGrid)
        {
            gameGrid.GetCell(2, 1).IsAlive = true;
            gameGrid.GetCell(2, 2).IsAlive = true;
            gameGrid.GetCell(2, 3).IsAlive = true;
        }
    }

    public class SmileyPattern : IGameOfLifePattern
    {
        public void AssignPattern(GOLGrid gameGrid)
        {
            gameGrid.GetCell(0, 0).IsAlive = true;
            gameGrid.GetCell(0, 1).IsAlive = true;
            gameGrid.GetCell(0, 3).IsAlive = true;
            gameGrid.GetCell(0, 5).IsAlive = true;
            gameGrid.GetCell(0, 6).IsAlive = true;
            gameGrid.GetCell(1, 3).IsAlive = true;
            gameGrid.GetCell(2, 0).IsAlive = true;
            gameGrid.GetCell(2, 6).IsAlive = true;
            gameGrid.GetCell(3, 1).IsAlive = true;
            gameGrid.GetCell(3, 2).IsAlive = true;
            gameGrid.GetCell(3, 3).IsAlive = true;
            gameGrid.GetCell(3, 4).IsAlive = true;
            gameGrid.GetCell(3, 5).IsAlive = true;
            gameGrid.GetCell(6, 0).IsAlive = true;
            gameGrid.GetCell(6, 1).IsAlive = true;
            gameGrid.GetCell(6, 2).IsAlive = true;
            gameGrid.GetCell(6, 4).IsAlive = true;
            gameGrid.GetCell(6, 5).IsAlive = true;
            gameGrid.GetCell(6, 6).IsAlive = true;
        }
    }

    public class DieHardPattern : IGameOfLifePattern
    {
        public void AssignPattern(GOLGrid gameGrid)
        {
            gameGrid.GetCell(1, 5).IsAlive = true;
            gameGrid.GetCell(4, 1).IsAlive = true;
            gameGrid.GetCell(4, 2).IsAlive = true;
            gameGrid.GetCell(5, 2).IsAlive = true;
            gameGrid.GetCell(5, 4).IsAlive = true;
            gameGrid.GetCell(5, 5).IsAlive = true;
            gameGrid.GetCell(5, 6).IsAlive = true;
        }
    }
}
