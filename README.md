# Spline Runner Demo

A Unity runner prototype based on spline movement.

## Implemented features

* Spline-based player movement
* Horizontal player control using pointer input
* Collectable objects with positive and negative values
* Wallet system and score tracking
* Player state changes based on collected points
* Character animation states
* Win and lose conditions
* Start, win and lose UI screens
* Follow camera system

## Project structure

Main gameplay systems are separated into:

* `Player` — controls player state and gameplay interactions
* `SplineFollower` — handles movement along the spline
* `Wallet` — stores collected points
* `Collectable` — collectible object logic
* `GameBootstrap` — initializes gameplay and connects systems

## Unity Version

Unity 2022.x
