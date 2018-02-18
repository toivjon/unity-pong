# unity-pong
A Unity implementation of the classic Pong game.

Contains a single game mode where two human players can play against each other.

## Scenes
The implementation is split into following scenes:
1. A welcome scene, which contains the main menu.
2. A court scene, which contains the actual gameplay.
3. An end game scene, which contains the results from the court scene.

The list scene transitions:
From | To  | Description                   
---- | --- | ---
1    | 2   | When a player starts the game by selecting the Start Game.
2    | 3   | When either player receives the 10th point (i.e. game is over).
3    | 1   | After the enter is pressed.

## Features
This Pong implementation contains the following features.
* Each game lasts until either player receives the 10th point.
* Both paddles are controlled by human players.
* Ball velocity is increased on each hit with a paddle.
* Ball velocity does not exceed the pre-defined maximum velocity.
* Ball movement is being stopped for a second after each reset.
* Ball direction is randomized from six different directions after each reset.
* Paddles are returned to the default position after each reset.

