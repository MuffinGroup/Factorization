using Godot;
using System;

public partial class Test : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _UnhandledInput(InputEvent @event) {
		var newPosition = Position;
		var newRotation = Rotation;

        if (@event is InputEventKey eventKey) {
			if (eventKey.Pressed && eventKey.Keycode == Key.A) {
				newPosition.X += 1;
				newPosition.Y += 1;
				newPosition.Z += 1;
			}
		}

		Position = newPosition;
		Rotation = newRotation;

        /* Nice!!!
        for (int test_loop = 0; test_loop <= 3; test_loop ++){
            test[test_loop] = "UwU";

            if (test_loop != 0 && test_loop != 1) {
                GD.Print(test);
            }
        }
        */
    }
}
