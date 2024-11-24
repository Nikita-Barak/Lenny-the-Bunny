# Lenny the Bunny
This is a simple 2D Unity project demonstrating basic gameloop mechanics.

[Itch.io link](https://shutafimpro.itch.io/lenny-the-bunny)

## Gameplay Features

### Player Movement 
The player controls the movement of the playable character via the WASD keys for basic movement and the Shift key for running.
The relevant scripts for getting player input and changing animations accordingly are:

- Player Input to Movement - [NewMover.cs](https://github.com/Nikita-Barak/Lenny-the-Bunny/blob/main/Assets/Scripts/AnimationController.cs)
- Movement to Animation Change - [AnimationController.cs](https://github.com/Nikita-Barak/Lenny-the-Bunny/blob/main/Assets/Scripts/AnimationController.cs)

---

### Player Interactions
When the player interacts with either an interactable item (a.k.a "Carrot") or an enemy (a.k.a "Fox"), different outcomes are set on occurance.

- **Carrot Interaction** - The carrot item disappears and a carrot counter is incremented.
  Corresponding code - [EatCarrot.cs](https://github.com/Nikita-Barak/Lenny-the-Bunny/blob/main/Assets/Scripts/EatCarrot.cs)

- **Enemy Collision** - The enemy fox will execute the player, making the player's dying component activate it's execution function.
  Corresponding code (from the player's perspective) - [Die.cs](https://github.com/Nikita-Barak/Lenny-the-Bunny/blob/main/Assets/Scripts/Die.cs)

- **Enivronment Collision** - Handled via colliders.

---

### Interactable Item Design
The interactable item, the "Carrot", is visually programmed to float and oscillate whilst it's shadow expands and shrinks accordingly.
In order for the shadow not to move when the carrot oscillates, a component responsible for keeping it still is applied.

- Item y-Axis Oscillation - [Oscillator.cs](https://github.com/Nikita-Barak/Lenny-the-Bunny/blob/main/Assets/Scripts/Oscillator.cs)
- Shadow Rescaling - [Scaler.cs](https://github.com/Nikita-Barak/Lenny-the-Bunny/blob/main/Assets/Scripts/Scaler.cs)
- Shadow Position Transformation - [StayPut.cs](https://github.com/Nikita-Barak/Lenny-the-Bunny/blob/main/Assets/Scripts/StayPut.cs)

---

### Enemy Design
The enemy AI is programmed to chase down the player when inside a capsular aggro-range around it, and kill the player on collision.

- Enemy Movement - [AIChaser.cs](https://github.com/Nikita-Barak/Lenny-the-Bunny/blob/main/Assets/Scripts/AIChaser.cs)
- Enemy Animation - [EnemyAnimationController.cs](https://github.com/Nikita-Barak/Lenny-the-Bunny/blob/main/Assets/Scripts/EnemyAnimationController.cs)
- Player Execution - [KillPlayer.cs](https://github.com/Nikita-Barak/Lenny-the-Bunny/blob/main/Assets/Scripts/KillPlayer.cs)

---

### Player Perspective and UI Design
The visuals displayed are based on 3 factors: The main camera, a virtual machine camera, and a minimap camera.

- **The Virtual Machine Camera** uses the following technique to almost-tightly follow the players' movement.
  
- **The Minimap Camera** is responsible to display parallel but different visuals on the bottom-right side of the screen.
  
- **UI Layer** Displays an overlay of:
  - The minimap camera in the bottom-right corner.
  - The carrot counter in the top-left corner.
 
Scaling to the main camera's perspective is also applied via a simple scaling component: [CameraScaler.cs](https://github.com/Nikita-Barak/Lenny-the-Bunny/blob/main/Assets/Scripts/CameraScaler.cs).
