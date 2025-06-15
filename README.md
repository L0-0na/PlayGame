# PlayGame
# PlayGame: Turn-Based Board Conquest Game

## 📌 Overview

PlayGame is a turn-based strategy game implemented in C#. The game simulates a battle for territorial control between two players over a grid-based board. Each player attempts to conquer neutral cells and attack enemy-controlled cells, using resources and weapons strategically.

## 🕹️ Gameplay

* The board is a grid (e.g., 7x7) of rectangles, each representing a cell.
* Each cell can belong to:

  * **Red**: Controlled by Player 1 (the enemy)
  * **Blue**: Controlled by Player 2 (the AI opponent)
  * **White**: Neutral (unclaimed)
* The objective is to convert the entire board to your color.

## ⚙️ Game Mechanics

* **Resources** and **weapons** are gathered each turn.
* **Player 2 (AI)** strategy:

  * Prioritizes conquering neutral (white) tiles.
  * Attacks red tiles when sufficient weapons are available.
  * Can force enemy retreat (convert blue back to white) to regain weapons.
* The game ends when all tiles are a single color.

## 🧩 Project Structure

* `GameBoard.cs`: Handles the grid, state of cells, painting, and game-end checks.
* `Playertwo.cs`: Contains AI logic for resource gathering, conquering, and attacking.
* `ResourceBoard.cs`: (Expected) Handles resource and weapon tile management.
* `Rect.cs`: Represents individual rectangles (cells) with color, position, and text.

## 💻 How to Run

### Requirements

* .NET SDK (C#)
* Visual Studio / Visual Studio Code / Any C# IDE

### Suggested Online Runners

* [.NET Fiddle](https://dotnetfiddle.net/)
* [Replit](https://replit.com/)
* [Gitpod](https://gitpod.io/)

### Build & Run

1. Clone or download the repository.
2. Open in your IDE.
3. Create a `Main` method to initialize `GameBoard`, `Playertwo`, and (optionally) `ResourceBoard`.
4. Call `Start()` on the `GameBoard`.
5. Loop through `PlayTurn()` until `GameEnd()` returns non-zero.

## 🚀 Future Improvements

* Improve AI strategy with advanced decision making.

## 📄 License

This project is released under the MIT License.
