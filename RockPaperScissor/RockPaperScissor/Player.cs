using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor
{
    public class Player
    {
        public Player()
        {
        }

        public Player (string name, string move)
        {
            Name = name;
            Move = move;
        }

        public string Name { get; set; }
        public string Move { get; set; }
    }
}
