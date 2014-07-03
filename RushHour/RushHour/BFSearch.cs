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

        // The state that is currently being processed.
        private State currentState;
        private bool solutionFound;

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
            while (stateQueue.Count > 0 && !solutionFound)
            {
                // State we're working on is the first element in the queue.
                currentState = stateQueue[0];

                // Remove the element we're checking from the queue.
                stateQueue.RemoveAt(0);

                // When the current state is already covered continue with the next state in the queue.
                if (compare(currentState, visitedStates))
                {
                    continue;
                }

                // Add current (processed) state to the visited list.
                visitedStates.Add(currentState);

                // Check for every vehicle on the board if the vehicle can move (in every direction).
                for (int i = 0; i < currentState.getBoard().getVehicleList().Count(); i++)
                {
                    {
                        Vehicle vehicle = currentState.getBoard().getVehicleList()[i];

                        // If vehicle is the red car, then try to move it to the right.
                        if (vehicle is RedCar)
                        {
                            // Check if current state is solution (has red car arrived on exit?).
                            if (currentState.getBoard().getVehicleList()[i].getX() == currentState.getBoard().goalXposition && currentState.getBoard().getVehicleList()[i].getY() + 1 == currentState.getBoard().goalYposition)
                            {
                                solutionFound = true;
                                continue;
                            }
                        }

                        if (vehicle.getDirection() == Vehicle.Direction.HORIZONTAL)
                        {
                            if (currentState.getBoard().moveDown(vehicle))
                            {
                                // If vehicle can move, clone the state and move the vehicle.
                                State clone = cloneState(currentState.getBoard(), currentState);
                                clone.getBoard().move(clone.getBoard().getVehicleList()[i], -1);

                                // Add the new state at the end of the queue for further processing (only if it is not in the queue or visited list).
                                if (!(compare(clone, stateQueue)) && !(compare(clone, visitedStates)))
                                {
                                    stateQueue.Add(clone);
                                }

                            }
                            if (currentState.getBoard().moveUp(vehicle))
                            {
                                State clone = cloneState(currentState.getBoard(), currentState);
                                clone.getBoard().move(clone.getBoard().getVehicleList()[i], 1);

                                if (!(compare(clone, stateQueue)) && !(compare(clone, visitedStates)))
                                {
                                    stateQueue.Add(clone);
                                }

                            }
                        }
                        if (vehicle.getDirection() == Vehicle.Direction.VERTICAL)
                        {
                            if (currentState.getBoard().moveLeft(vehicle))
                            {
                                State clone = cloneState(currentState.getBoard(), currentState);
                                clone.getBoard().move(clone.getBoard().getVehicleList()[i], -1);

                                if (!(compare(clone, stateQueue)) && !(compare(clone, visitedStates)))
                                {
                                    stateQueue.Add(clone);
                                }
                            }
                            if (currentState.getBoard().moveRight(vehicle))
                            {
                                State clone = cloneState(currentState.getBoard(), currentState);
                                clone.getBoard().move(clone.getBoard().getVehicleList()[i], 1);

                                if (!(compare(clone, stateQueue)) && !(compare(clone, visitedStates)))
                                {
                                    stateQueue.Add(clone);
                                }
                            }
                        }
                    }
                }
            }
            // Shows the solution when it is found.
            if (solutionFound)
            {
                Console.WriteLine("Solution found. Press any key to show the solution (from end to beginning).");
                Console.ReadKey();
                showSolution(currentState);
            }
            else
            {
                Console.WriteLine("Finished. No solution found.");
            }
        }

        // Helper function to check is a state is already in a list.
        public bool compare(State state, List<State> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // If same board is found, return true.
                if (state.getBoard().getBoardString() == list[i].getBoard().getBoardString())
                {
                    return true;
                }
            }
            return false;
        }

        // Helper function to clone a state.
        public State cloneState(RushHourBoard rushHourBoard, State parent)
        {
            return new State(rushHourBoard.cloneRushHourBoard(), parent);
        }

        // Print the solution, beginning with the solution state to the initial state.
        public void showSolution(State endState)
        {
            bool finished = false;

            // Print the current board (the board that is the solution).
            endState.getBoard().printBoard();

            // Get the first parent state.
            State parentState = endState.getParent();

            if (parentState != null)
            {
                // Print the first parent state board.
                parentState.getBoard().printBoard();

                // Display all the underlaying parent state boards.
                while (!finished)
                {
                    parentState = parentState.getParent();

                    if (parentState != null)
                    {
                        parentState.getBoard().printBoard();
                    }
                    else
                    {
                        // Stop if we have printed all states (reached the initial state, whose parent state in null).
                        finished = true;
                    }
                }

                Console.WriteLine("Finished printing solution.");
            }
        }
    }
}