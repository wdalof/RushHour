using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class State
    {
        RushHourBoard board;
        State parent;

        public State(RushHourBoard board, State parent)
        {
            this.board = board;
            this.parent = parent;
        }

        public RushHourBoard GetBoard()
        {
            return board;
        }
    }
}
