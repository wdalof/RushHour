using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class State
    {
        RushHourBoard _board;
        State _parent;

            public State(RushHourBoard board, State parent){
                _board = board;
                _parent = parent;
            }
    }
}
