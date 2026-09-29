# 🎲 Apex Roll

**Apex Roll** is a single-player, turn-based board game built with **C# and Unity**.

The player starts at Tile 1 and rolls a six-sided dice to move across a 30-tile board. The objective is to reach the finish within the available turns while dealing with special Boost and Trap tiles.

## 🎮 Gameplay

- 30-tile serpentine board
- Six-sided dice (1–6)
- Limited number of turns
- Step-by-step player movement
- Boost and Trap tiles
- Win and Game Over conditions
- Play Again / Restart functionality
- WebGL build for browser-based gameplay

### Special Tiles

| Tile | Type | Effect |
|------|------|--------|
| 7 | Boost | Move forward 2 spaces |
| 14 | Trap | Move backward 3 spaces |
| 21 | Boost | Move forward 2 spaces |
| 25 | Trap | Move backward 3 spaces |
| 30 | Finish | Win the game |

## 🕹️ How to Play

1. Click **Roll Dice**.
2. The dice generates a value between **1–6**.
3. The player moves one tile at a time based on the result.
4. If the player lands on a special tile, its effect is applied.
5. Reach **Tile 30** to win.
6. Reach the turn limit without finishing to trigger **Game Over**.
7. Use **Play Again** to restart the game.

## 🧠 Game Flow

```text
Idle
  ↓
Rolling
  ↓
Moving
  ↓
Check Special Tile
  ↓
Check Win / Game Over
  ↓
Idle
```

The game uses a simple **state-driven architecture** to control game progression and valid player actions.

## 🏗️ Architecture

The game is divided into modular components:

| Component | Responsibility |
|-----------|----------------|
| `GameManager` | Game flow, turns, states and win conditions |
| `Player` | Player position and movement |
| `Board` | Board generation and tile management |
| `BoardTile` | Tile number and tile type |
| `Dice` | Dice generation |
| `UIManager` | Game UI and end-game screens |

## 💻 C# Concepts Used

- **Object-Oriented Programming** — separated game functionality into dedicated classes
- **Classes & Objects** — `GameManager`, `Player`, `Board`, `Dice`, etc.
- **Encapsulation** — controlled access to game data through private fields and properties
- **Enums** — used for `GameState` and `TileType`
- **Properties** — exposed read-only game information such as the player's current tile
- **Arrays / Collections** — maintained and accessed board tile references
- **Coroutines** — implemented step-by-step player movement with timed execution
- **State-driven game flow** — controlled transitions between `Idle`, `Rolling`, `Moving`, `CheckWin`, `Win`, and `GameOver`

## 🎮 Unity Concepts Used

- **MonoBehaviour** — implemented game systems as Unity components
- **GameObjects & Components** — structured the player, board, tiles, dice, and UI
- **Prefabs** — dynamically generated board tiles from a reusable tile prefab
- **Transform** — positioned and moved tiles and the player
- **Unity UI** — implemented buttons, game information, and end-game screens
- **TextMeshPro** — displayed tile numbers and game information
- **Inspector & `[SerializeField]`** — configured component references and gameplay values through the Unity Editor
- **Coroutines** — handled timed player movement
- **WebGL** — built the game for browser-based gameplay

## 🛠️ Tech Stack

**C# · Unity · TextMeshPro · WebGL · Git · GitHub**

## 🌐 Play

**WebGL Demo:** Coming soon

## 🚀 Run Locally

Clone the repository:

```bash
git clone https://github.com/Gowreesh10/Apex-Roll.git
```

Open the project using **Unity Hub**, open the main game scene, and press **Play**.

## 🎯 Project Goal

This project was built to gain practical experience with **C# programming, Unity game development, game architecture, coroutines, state management, and WebGL deployment**.