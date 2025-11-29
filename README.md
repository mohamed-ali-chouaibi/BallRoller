# Ball Roller - Endless Runner Game

A fast-paced endless runner game built with Unity where you control a ball rolling through an infinite track, dodging obstacles and collecting coins.

## Gameplay

- **Objective**: Survive as long as possible while collecting coins
- **Controls**: Use A/D or Arrow Keys to move left and right
- **Scoring**: Distance traveled + coins collected
- **Challenge**: Avoid obstacles or it's game over!

## Features

- **Infinite procedural generation** - obstacles and coins spawn dynamically
- **Physics-based movement** - smooth ball rolling with Rigidbody physics
- **Score tracking** - distance-based score and coin counter
- **Audio system** - background music and sound effects
- **Game state management** - main menu, pause, and game over screens
- **Performance optimized** - automatic cleanup of passed objects

## Game Mechanics

### Player Movement
- Ball automatically accelerates forward to target speed (100 units/s)
- Lateral movement constrained to a 6-unit wide track (-3 to +3)
- Responsive horizontal controls with smooth physics

### Obstacle System
- Random obstacle spawning at 15-unit intervals
- 50% chance for coins vs obstacles
- Multiple obstacle prefab variations (T, I, Cu, Obs, Obst)
- Spawns 200 units ahead of player position

### Infinite Ground
- Seamless ground tile recycling
- Triggers reposition tiles as player progresses
- Creates endless running experience

## Technical Details

### Core Scripts

- `PlayerMovement.cs` - Player physics and collision detection
- `ObstacleGenerator.cs` - Procedural obstacle/coin spawning
- `GameStateManager.cs` - Game state and UI management
- `InfiniteGround.cs` - Ground tile recycling system
- `CoinManager.cs` - Coin collection tracking
- `ScoreManager.cs` - Distance-based scoring
- `AudioManager.cs` - Music and SFX management
- `Destroyer.cs` - Object cleanup for performance