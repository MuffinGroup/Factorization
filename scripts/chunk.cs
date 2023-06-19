using Godot;
using System;

public partial class chunk : StaticBody3D
{

	Vector3[] verticies = new Vector3[8];
	int[] TOP = new[] { 2, 3, 7, 6 };
	int[] BOTTOM = new[] { 0, 4, 5, 1 };
	int[] LEFT = new[] { 6, 4, 0, 2 };
	int[] RIGHT = new[] { 3, 1, 5, 7 };
	int[] FRONT = new[] { 7, 5, 4, 6 };
	int[] BACK = new[] { 2, 0, 1, 3 };

	SurfaceTool surfaceTool = new();
	Mesh mesh = null;
	MeshInstance3D meshInstance = null;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		verticies = VectorHandler();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (meshInstance != null)
		{
			meshInstance.CallDeferred("queue_free");
			meshInstance = null;
		}

		mesh = new Mesh();
		meshInstance = new MeshInstance3D();
		surfaceTool.Begin(Mesh.PrimitiveType.Triangles);

		for (int x = 0; x < Global.DIMENSION.X; x++)
		{
			for (int y = 0; y < Global.DIMENSION.Y; y++)
			{
				for (int z = 0; z < Global.DIMENSION.Z; z++)
				{
					GD.Print("looping through ");
				}
			}
		}
	}

	public Vector3[] VectorHandler()
	{
		verticies[0] = new Vector3(0, 0, 0);
		verticies[1] = new Vector3(1, 0, 0);
		verticies[2] = new Vector3(0, 1, 0);
		verticies[3] = new Vector3(1, 1, 0);
		verticies[4] = new Vector3(0, 0, 1);
		verticies[5] = new Vector3(1, 0, 1);
		verticies[6] = new Vector3(0, 1, 1);
		verticies[7] = new Vector3(1, 1, 1);
		return verticies;
	}
}
