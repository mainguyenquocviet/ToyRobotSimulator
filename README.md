# Toy Robot Simulator

This is a console application that simulates a toy robot moving on a square tabletop, of dimensions 5 units x 5 units. The robot can be controlled by commands to move around the table and report its position and direction. The robot must be prevented from falling off the table.

## Features

- The robot is placed on a 5x5 tabletop.
- Commands to control the robot include:
  - `PLACE X,Y,F`: Places the robot at position (X,Y) facing the direction F (NORTH, SOUTH, EAST, WEST).
  - `MOVE`: Moves the robot one unit forward in the direction it is currently facing.
  - `LEFT`: Rotates the robot 90 degrees to the left.
  - `RIGHT`: Rotates the robot 90 degrees to the right.
  - `REPORT`: Outputs the current position and direction of the robot.
- The robot ignores any move that would cause it to fall off the table.
- Commands can be input from a file named `commands.txt`.

### Running the Application

1. Clone the repository or download the project files.
2. Open the project directory in your terminal.
3. Create a `commands.txt` file in the project root directory with the desired commands.
4. Build and run the application:

### Example of what the commands.txt file might look like:
PLACE 0,0,NORTH
MOVE
REPORT
PLACE 0,0,NORTH
LEFT
REPORT
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
PLACE 4,4,NORTH
MOVE
REPORT
PLACE 4,4,EAST
MOVE
REPORT
PLACE 0,0,SOUTH
MOVE
REPORT
PLACE 0,0,WEST
MOVE
REPORT
PLACE 3,3,NORTH
MOVE
MOVE
RIGHT
MOVE
MOVE
LEFT
MOVE
REPORT
