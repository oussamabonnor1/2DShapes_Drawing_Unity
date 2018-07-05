# 2DShapes_Drawing_Unity

## Screenshots and GIFs:
coming soon...

## Project logic:
The use of vertices specified from the cursor's coordinates clicks to dynamically generate and configure a mesh, rigidbody2D, color, and 2D collider.

## Project Overview
Requires Unity3D (tested with 2018.x, but should also work with 2017.x & 5.x)

```
.
├── _Materials
|   └── Line color.mat           - The color of the line drawn when displaying the current shape (before creation).
├── _Scenes
|   └── Main.unity               - The project's main scene
└── Scripts
    ├── GameManager.cs           - The main code of creation and interaction.
    └── Traingulator.cs          - Generates triangles from polygon vertecies.
```

## Running the Project
To run the project, open _Scenes/Main.unity and click on the play button.

Click anywhere on the screen and draw a shape using multiples left mouse button clicks, once done click on the right mouse button to generate the shape and enjoy the physics! (Be creative). 
