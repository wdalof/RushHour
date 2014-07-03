using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    // A state is a "snapshot" of a rush hour board with a parent board linked to it.
    class State
    {
        RushHourBoard board;
        State parent;

        public State(RushHourBoard board, State parent)
        {
            this.board = board;
            this.parent = parent;
        }

        public RushHourBoard getBoard()
        {
            return board;
        }

        public State getParent()
        {
            return this.parent;
        }
    }
}
