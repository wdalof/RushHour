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
        private List<State> visitedStates = new List<State>();

        // List of states that have to be examined.
        private List<State> stateQueue = new List<State>();

        private RushHourBoard initialBoard;

        public BFSearch(RushHourBoard initialBoard)
        {
            this.initialBoard = initialBoard;
        }

        public void solve()
        {
            // Create a state of the initial board, and add it to the queue.
            State initialState = new State(initialBoard, null);
            stateQueue.Add(initialState);

            // Keep processing while the queue is not empty.
            while (stateQueue.Count > 0)
            {
                // State we're working on is the first element in the queue.
                State currentState = stateQueue[0];

                // Remove the element we're checking from the queue.
                stateQueue.RemoveAt(0);

                // When the current state is already covered continue with the next state in the queue.
                if (compare(currentState, visitedStates))
                {
                    continue;
                }

                // Check for every vehicle on the board if the vehicle can move (in every direction).
                foreach (Vehicle vehicle in currentState.GetBoard().getVehicleList())
                {
                    // If vehicle is the red car, then try to move it to the right.
                    if (vehicle is RedCar)
                    {
                        // Create temponary state.
                        State temp = cloneState(currentState.GetBoard(), currentState);

                        // Keep trying to move the red car to the right.
                        while (temp.GetBoard().moveUp(vehicle))
                        {
                            // Move the red car to the right.
                            // temp.GetBoard().move(vehicle, 1);

                            // Check if current state is solution (has red car arrived on exit?).
                            if (temp.GetBoard().goalXposition == 'r' && temp.GetBoard().goalYposition == 'r')
                            {
                                Console.WriteLine("Done. Goal reached.");
                                temp.GetBoard().printBoard();
                                break;
                            }
                        }
                    }

                    if (vehicle.getDirection() == Vehicle.Direction.HORIZONTAL)
                    {
                        if (currentState.GetBoard().moveDown(vehicle))
                        {
                            // If vehicle can move, clone the state and move the vehicle.
                            State clone = cloneState(currentState.GetBoard(), currentState);
                            clone.GetBoard().move(vehicle, -1);
                            clone.GetBoard().printBoard();

                            // Add the new state at the end of the queue for further processing (only if it is not in the queue or visited list).
                            if (!(compare(clone, stateQueue)) && !(compare(clone, visitedStates)))
                            {
                                stateQueue.Add(clone);
                            }
                        }
                        if (currentState.GetBoard().moveUp(vehicle))
                        {
                            State clone = cloneState(currentState.GetBoard(), currentState);
                            clone.GetBoard().move(vehicle, 1);
                            clone.GetBoard().printBoard();

                            if (!(compare(clone, stateQueue)) && !(compare(clone, visitedStates)))
                            {
                                stateQueue.Add(clone);
                            }

                        }
                    }
                    if (vehicle.getDirection() == Vehicle.Direction.VERTICAL)
                    {
                        if (currentState.GetBoard().moveLeft(vehicle))
                        {
                            State clone = cloneState(currentState.GetBoard(), currentState);
                            clone.GetBoard().move(vehicle, -1);
                            clone.GetBoard().printBoard();

                            if (!(compare(clone, stateQueue)) && !(compare(clone, visitedStates)))
                            {
                                stateQueue.Add(clone);
                            }
                        }
                        if (currentState.GetBoard().moveRight(vehicle))
                        {
                            State clone = cloneState(currentState.GetBoard(), currentState);
                            clone.GetBoard().move(vehicle, 1);
                            clone.GetBoard().printBoard();

                            if (!(compare(clone, stateQueue)) && !(compare(clone, visitedStates)))
                            {
                                stateQueue.Add(clone);
                            }
                        }
                    }
                }
                // Add current (processed) state to the visited list.
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

        // Helper function to clone a state.
        public State cloneState(RushHourBoard rushHourBoard, State parent)
        {
            return new State(rushHourBoard, parent);
        }
    }
}