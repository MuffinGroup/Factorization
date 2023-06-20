using Godot;
using System;

public partial class Camera3D : Godot.Camera3D {

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) {
    }

    public override void _UnhandledInput(InputEvent @event) {
        var newPosition = Position;
        var newRotation = Rotation;
        if (@event is InputEventKey eventKey) {
            if (eventKey.Pressed && eventKey.Keycode == Key.Up) {
                newPosition.Y += 1.0f;
            }
            if (eventKey.Pressed && eventKey.Keycode == Key.Down) {
                newPosition.Y -= 1.0f;
            }
            if (eventKey.Pressed && eventKey.Keycode == Key.Right) {
                newRotation.Y -= 0.1f;
            }
            if (eventKey.Pressed && eventKey.Keycode == Key.Left) {
                newRotation.Y += 0.1f;
            }
        }
        Position = newPosition;
        Rotation = newRotation;

    }

    public String[] test = new String[3];
}
