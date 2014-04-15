using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class BFSearch
    {
        //Keep track of the states that are already visited.
        public List<State> visitedStates = new List<State>();

        //List of states that have to be examined.
        public List<State> stateQueue = new List<State>();

        public RushHourBoard initialBoard;

        public BFSearch(RushHourBoard initialBoard)
        {
            this.initialBoard = initialBoard;
        }

        //public void Solve()
        //{
        //    //Create a state of the initial board, and add it to the queue.
        //    State initialState = new State(initialBoard, null);
        //    stateQueue.Add(initialState);

        //    while (stateQueue.Count > 0)
        //    {
        //        State currentState = stateQueue[stateQueue.Count - 1];

        //        //When the current state is already covered continue with the next state in the queue.
        //        if (Compare(currentState, visitedStates))
        //        {
        //            continue;
        //        }
        //    }
        //}

        //Helper function to check is a state is already in a list.
        //public bool Compare(State state, List<State> list)
        //{
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        //If same board is found, return true.
        //        if (state.GetBoard().GetBoardString() == list[i].GetBoard().GetBoardString())
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
