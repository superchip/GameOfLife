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
}
