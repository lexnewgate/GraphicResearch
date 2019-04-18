using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var game=new Game(800,600,"OpenTkTest"))
            {
                game.Run();
            }
        }
    }
}
