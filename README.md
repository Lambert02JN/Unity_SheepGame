# Unity_SheepGame

A 3D action game prototype built in **Unity 2018.3.14f1**. The player controls a sheep and can transform into two combat forms while moving through an environment with boars and wolves. This project is presented as a **programming portfolio piece**: my original contribution is the C# gameplay code. Character models, animations, environment art, effects, and other visual assets were sourced from Unity Asset Store packages or other third-party assets; I do not claim authorship of them.

## Gameplay and technical features

- **Three playable forms:** sheep, black combat form, and white combat form. Form changes instantiate the corresponding player prefab and transfer the player to its current position.
- **Movement and camera:** camera-relative movement, character rotation toward the movement direction, acceleration after about two seconds of continuous movement, and a mouse-controlled follow camera.
- **Combat:** a basic attack, a skill, and a stronger skill with animation-triggered hit detection, damage, effects, and skill-bar consumption. Combat actions apply to the non-sheep forms.
- **Enemy behavior:** boars seek lettuce targets; wolves select between a boar and the player based on distance. Enemies pursue and attack nearby targets.
- **Game UI:** player health and skill bars, enemy health, transformation indicators, and a form-selection prompt when the relevant health threshold is reached.

## Controls

| Input | Action |
| --- | --- |
| `W` `A` `S` `D` / arrow keys | Move using Unity's default Horizontal and Vertical axes. Keep moving for about two seconds to accelerate. |
| Move mouse | Rotate the follow camera. |
| Left mouse button | Basic attack in a combat form. |
| Right mouse button | Use a skill in a combat form. |
| Hold `E` + right mouse button | Use the stronger skill in a combat form. |
| `R` | Transform into the black combat form. |
| `F` | Transform into the white combat form when the form is available. |
| `V` | Return to sheep form. |
| `S` near a house door | Leave the house while in sheep form. |

The scripts also contain controller button mappings. Controller behavior may depend on the project's Unity Input Manager configuration and the connected device.

## Run the project

1. Clone or download this repository.
2. Open the project folder in **Unity 2018.3.14f1**.
3. Open `Assets/Scene/gameSystem.unity` and press **Play**.

## My contribution and asset attribution

I wrote the gameplay C# scripts in [`Assets/Script`](Assets/Script), including player controls and transformation, animal behavior, combat and damage, camera movement, UI bars, and game state handling. This project demonstrates my programming and Unity integration skills. The character art, animations, environmental art, and visual assets are third-party assets, not original artwork by me. The repository also contains scripts inside imported asset packages under `Assets/Asset`; those package scripts are **not** part of my claimed programming contribution.

**Portfolio context:** This is one technical piece within a larger application portfolio. Please assess the original gameplay programming and how the systems are integrated, rather than treating the third-party visual assets as my artwork.

## Project structure

| Path | Description |
| --- | --- |
| [`Assets/Script/Animal`](Assets/Script/Animal) | Player and animal behavior. |
| [`Assets/Script/Animation`](Assets/Script/Animation) | Animation state behaviors used by combat. |
| [`Assets/Script/System`](Assets/Script/System) | Camera, UI, damage, bars, and game systems. |
| [`Assets/Scene/gameSystem.unity`](Assets/Scene/gameSystem.unity) | Main gameplay scene. |

## Repository

[View Unity_SheepGame on GitHub](https://github.com/Lambert02JN/Unity_SheepGame)
