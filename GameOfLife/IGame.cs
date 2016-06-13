using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    ///  This Interface is for defining basic game functionallity
    /// </summary>
    interface IGame
    {
        void Play();
        void Pause();
        void Restart();
        void Stop();
    }

    /// <summary>
    ///  Game Factory to create all kinds of games
    /// </summary>
    class GameFactory
    {
        public enum GameName { GameOfLife }
        public static IGame CreateGridGame(GameName gameName,int rows, int columns)
        {
            IGame game = null;

            switch (gameName)
            {
                
                case GameName.GameOfLife:
                    game = new GameOfLifeGame(rows, columns);
                    break;
                default:
                    game = new GameOfLifeGame(rows, columns);
                    break;
            }

            return game;
        }
    }

}
