using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class BFSearch
    {
        // Keep track of the states that are already visited.
        public List<State> visitedStates = new List<State>();

        // List of states that have to be examined.
        public List<State> stateQueue = new List<State>();

        public RushHourBoard initialBoard;

        public BFSearch(RushHourBoard initialBoard)
        {
            this.initialBoard = initialBoard;
        }

        public void solve()
        {
            // Create a state of the initial board, and add it to the queue.
            State initialState = new State(initialBoard, null);
            stateQueue.Add(initialState);

            while (stateQueue.Count > 0)
            {
                State currentState = stateQueue[stateQueue.Count - 1];

                // When the current state is already covered continue with the next state in the queue.
                if (compare(currentState, visitedStates))
                {
                    stateQueue.RemoveAt(stateQueue.Count - 1);
                    continue;
                }

                // Check if a vehicle can move.
                foreach (Vehicle vehicle in currentState.GetBoard().getVehicleList())
                {
                    if (vehicle.getDirection() == Vehicle.Direction.HORIZONTAL)
                    {
                        if (currentState.GetBoard().moveDown(vehicle))
                        {
                            // If vehicle can move, clone the state and move the vehicle.
                            State clone = cloneState(currentState.GetBoard(), currentState);
                            clone.GetBoard().move(vehicle, -1);

                            stateQueue.Add(clone);
                        }
                        if (currentState.GetBoard().moveUp(vehicle))
                        {
                            State clone = cloneState(currentState.GetBoard(), currentState);
                            clone.GetBoard().move(vehicle, 1);

                            stateQueue.Add(clone);
                        }
                    }
                    if (vehicle.getDirection() == Vehicle.Direction.VERTICAL)
                    {
                        if (currentState.GetBoard().moveLeft(vehicle))
                        {
                            State clone = cloneState(currentState.GetBoard(), currentState);
                            clone.GetBoard().move(vehicle, -1);

                            stateQueue.Add(clone);
                        }
                        if (currentState.GetBoard().moveRight(vehicle))
                        {
                            State clone = cloneState(currentState.GetBoard(), currentState);
                            clone.GetBoard().move(vehicle, 1);

                            stateQueue.Add(clone);
                        }
                    }
                }

                // Add current (processed) state to the list.
                visitedStates.Add(currentState);
            }
        }

        // Helper function to check is a state is already in a list.
        public bool compare(State state, List<State> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // If same board is found, return true.
                if (state.GetBoard().getBoardString() == list[i].GetBoard().getBoardString())
                {
                    return true;
                }
            }
            return false;
        }

        public State cloneState(RushHourBoard rushHourBoard, State parent)
        {
            return new State(rushHourBoard, parent);
        }
    }
}
