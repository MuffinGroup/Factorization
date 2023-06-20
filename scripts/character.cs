using Godot;
using System;

public partial class character : CharacterBody3D
{
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	private Node3D neck;
	private Camera3D camera;

	public override void _Ready() {
		neck = GetNode<Node3D>("neck");
		camera = GetNode<Camera3D>("neck/Camera3D");
	}

	public override void _UnhandledInput(InputEvent @Event){
		var newRotation = neck.Rotation;

		if (@Event is InputEventMouseButton eventMouseButton && eventMouseButton.Pressed){
			switch (eventMouseButton.ButtonIndex){
				case MouseButton.Right:
					Input.MouseMode = Input.MouseModeEnum.Hidden;
					break;
			}
		}

		if (@Event is InputEventKey eventKey) {
            if(eventKey.Pressed && eventKey.Keycode == Key.Escape){
				Input.MouseMode = Input.MouseModeEnum.Visible;
			}
        }

		if (@Event is InputEventMouseMotion eventMouseMotion && Input.MouseMode == Input.MouseModeEnum.Hidden){
			neck.RotateY(-eventMouseMotion.Relative.X * 0.01f);
			neck.RotateX(-eventMouseMotion.Relative.Y * 0.01f);
			newRotation.X = Math.Clamp(neck.Rotation.X, 30 / 360, 60 / 360);
		}

		neck.Rotation = newRotation;
	}
	

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("left", "right", "forward", "back");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
