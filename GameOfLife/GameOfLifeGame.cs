using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    ///  This class repersent GameOfLife game
    /// </summary>
    class GameOfLifeGame : GridGame
    {
        private const int SleepTime = 1000;

        private GOLGrid _gameGrid;
        private Neighberhood _neighberhood;
        private IGameOfLifePattern _golPattern;

        public GameOfLifeGame(int rows, int columns) : base(rows, columns)
        {
            _gameGrid = new GOLGrid(rows, columns);
            prepareGame();
        }

        public override void Pause()
        {

        }

        public override void Play()
        {
            //TODO - fix
            while(true)
            {
                displayGame();
                makeMove();              
                Thread.Sleep(SleepTime);
            }
        }

        public override void Restart()
        {

        }

        public override void Stop()
        {
                
        }
        
        private void displayGame()
        {
            for (int i = 0; i < _rows; ++i)
            {
                Console.WriteLine();
                for (int j = 0; j < _columns; ++j)
                {
                    if (_gameGrid.GetCell(i, j).IsAlive)
                        Console.Write(" X ");
                    else
                        Console.Write(" - ");
                }

            }

            Console.WriteLine("\n\n\n===================\n");
        }

        /// <summary>
        ///  Preparing the inital game grid
        /// </summary>
        private void prepareGame()
        {
            // Randomizing Pattern
            Random rand = new Random(System.Environment.TickCount);
            _golPattern = PatternFactory.CreatePattern((PatternFactory.Pattern)rand.Next(0, 3));
            _golPattern.AssignPattern(_gameGrid);

            // Updating neighberhood with game grid
            _neighberhood = new Neighberhood(_gameGrid);
        }

        /// <summary>
        ///  Making the game move, updating the current nighbours and reanlyzing the grid
        /// </summary>
        private void makeMove()
        {
            updateCellNeighboursCount();

            for (int i = 0; i < _rows; ++i)
            {
                for (int j = 0; j < _columns; ++j)
                {
                    updateLifeStatus(_gameGrid.GetCell(i, j));
                }

            }
        }

        /// <summary>
        ///  Updating the cel living neighbours
        /// </summary>
        private void updateCellNeighboursCount()
        {
            for (int i = 0; i < _rows; ++i)
            {
                for (int j = 0; j < _columns; ++j)
                {
                    GOLCell cell = _gameGrid.GetCell(i, j);
                    _neighberhood.UpdateLiveNeighborsCount(cell);
                }
            }
        }

        /// <summary>
        ///  Game of life logic
        /// </summary>
        private void updateLifeStatus(GOLCell cell)
        {
            int liveNeighbours = cell.LiveNeighboursCount;

            if(cell.IsAlive)
            {
                if (liveNeighbours < 2)
                    cell.IsAlive = false;
                else if (liveNeighbours == 2 || liveNeighbours == 3)
                    cell.IsAlive = true;
                else if (liveNeighbours > 3)
                    cell.IsAlive = false;
            }
            else
            {
                if (liveNeighbours == 3)
                    cell.IsAlive = true;
            }
        }

    }


    /// <summary>
    ///  This class defines a Grid of the Game Of Life game
    /// </summary>
    public class GOLGrid : Grid
    {
        private GOLCell[,] _gridCells;

        public GOLGrid(int rows, int columns) : base(rows, columns)
        {
            init();
        }

        public GOLCell GetCell(int row, int column)
        {
            return _gridCells[row, column];
        }

        private void init()
        {
            if (_rows > 0 && _columns > 0)
            { 
                _gridCells = new GOLCell[_rows, _columns];

                for (int i = 0; i < _rows; ++i)
                {
                    for (int j = 0; j < _columns; ++j)
                    {
                        _gridCells[i, j] = new GOLCell(i,j);
                    }

                }
            }
        }


    }

    /// <summary>
    ///  This class defines a Cell of the Game Of Life game
    /// </summary>
    public class GOLCell : GridCell
    {
        public GOLCell(int x, int y)
        {
            PositionX = x;
            PositionY = y;
            IsAlive = false;
        }

        public bool IsAlive { get; set; }
        public int LiveNeighboursCount { get; set; }
    }

    /// <summary>
    ///  This class is responsible for quering the cell surrounding aka neiberhood 
    /// </summary>
    class Neighberhood
    {
        GOLGrid _grid;

        public Neighberhood(GOLGrid grid)
        {
            _grid = grid;
        }

        /// <summary>
        ///  Updating the live cell neighbors of the cell (total of 8 neighbours)
        /// </summary>
        public void UpdateLiveNeighborsCount(GOLCell cell)
        {
            int neighborsCount = 0;

            // go left
            if (cell.PositionY > 0)
            {
                if(_grid.GetCell(cell.PositionX, cell.PositionY - 1).IsAlive)
                {
                    ++neighborsCount;
                }

            }

            // go right
            if (cell.PositionY < _grid.Columns - 1)
            {
                if (_grid.GetCell(cell.PositionX, cell.PositionY + 1).IsAlive)
                {
                    ++neighborsCount;
                }

            }

            // go up
            if (cell.PositionX > 0)
            {
                if (_grid.GetCell(cell.PositionX - 1, cell.PositionY).IsAlive)
                {
                    ++neighborsCount;
                }
            }

            // go down
            if (cell.PositionX < _grid.Rows - 1)
            {
                if (_grid.GetCell(cell.PositionX + 1, cell.PositionY).IsAlive)
                {
                    ++neighborsCount;
                }

            }

            // go up left
            if (cell.PositionY > 0 && cell.PositionX > 0)
            {
                if (_grid.GetCell(cell.PositionX - 1, cell.PositionY - 1).IsAlive)
                {
                    ++neighborsCount;
                }
            }

            // go down left
            if (cell.PositionY > 0 && cell.PositionX < _grid.Rows - 1)
            {
                if (_grid.GetCell(cell.PositionX + 1, cell.PositionY - 1).IsAlive)
                {
                    ++neighborsCount;
                }
            }

            // go down right
            if (cell.PositionY < _grid.Columns - 1 && cell.PositionX < _grid.Rows - 1)
            {
                if (_grid.GetCell(cell.PositionX + 1, cell.PositionY + 1).IsAlive)
                {
                    ++neighborsCount;
                }
            }

            // go up right
            if (cell.PositionY < _grid.Columns - 1 && cell.PositionX > 0)
            {
                if (_grid.GetCell(cell.PositionX - 1, cell.PositionY + 1).IsAlive)
                {
                    ++neighborsCount;
                }
            }

            cell.LiveNeighboursCount = neighborsCount;
        }


    }

}
