# 🎲 Unity Dice Roll Simulation

A Unity-based simulation for rolling two 3D dice using physics-based motion and result detection. Each dice roll is randomized with force and torque, and the final values are determined using trigger detection. The dice results are displayed on screen with smooth animations.

## 🧩 Features

- Physics-based dice rolling
- Accurate face detection using triggers
- Animated positioning of dice after roll
- UI display of total score
- Easily extendable to support more dice

## 📦 Components

### `DiceSide.cs`
- Attached to each side of a die.
- Detects which side is facing down by checking ground collision.

### `DiceStats.cs`
- Handles physics detection to determine if a die is balanced/still.
- Calculates the score based on which side is on the ground.
- Animates the dice to a fixed screen position after result is known.

### `DiceManager.cs`
- Spawns and manages two dice.
- Controls rolling logic and final score display.
- Manages UI updates and score display.

## ▶️ Getting Started

### Requirements
- Unity 2020.3 or newer
- Rigidbody-enabled dice prefab with correctly named child sides (1–6)
- Each side of the die must have a `DiceSide` script and a trigger collider

### How to Use
1. Attach `DiceManager` to an empty GameObject in your scene.
2. Assign the Dice prefab (with 6 child sides + DiceSide script) to `DicePrefab`.
3. Set the `DiceOnScreenPosition` to where you want the result dice to animate to.
4. Link a `Text` UI element to the `display` field for score output.
5. Call `throwDice()` (e.g., via UI button) to initiate a roll.

## 📂 Project Structure
Assets/
├── Scripts/
│   ├── DiceSide.cs
│   ├── DiceStats.cs
│   └── DiceManager.cs
├── Prefabs/
│   └── Dice.prefab
└── UI/
    └── ScoreDisplay (Text)


## 🛠️ Customization
- Modify the `ShowDiceToTheScreen()` method to change how and where dice animate after rolling.
- Extend `DiceManager` to support more than 2 dice or integrate with game logic.

## 🎮 Demo
A short demo video or GIF here would showcase the physics rolling and final animation. *(Optional)*

## 📄 License
This project is open-source and free to use in personal or commercial projects. Attribution appreciated but not required.

---
