using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    ///  This abstract class defines games with grid (matrice)
    /// </summary>
    /// <example> 
    /// Tic Tac Toe, Game of life, Battleships, etc...
    /// </example> 
    abstract class GridGame : IGame
    {
        protected int _rows, _columns;
        protected int _movesCount;
        protected int _movesCountLimit;

        /// <summary>
        ///  Constractor for any grid game
        /// </summary>
        /// <param name="rows">game rows</param>
        /// <param name="columns">game columns</param>
        public GridGame(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
        }

        public abstract void Pause();

        public abstract void Play();

        public abstract void Restart();

        public abstract void Stop();

    }

    /// <summary>
    ///  This class defines a Grid for game grid type games
    /// </summary>
    public class Grid
    {
        protected int _rows;
        protected int _columns;

        public Grid(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;      
        }

        public int Rows { get { return _rows; } }
        public int Columns { get { return _columns; } }
    }

    /// <summary>
    ///  This class defines a GridCell for game grid type game
    /// </summary>
    public class GridCell
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }


}
