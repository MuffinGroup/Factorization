using Godot;
using Microsoft.VisualBasic;
using System;
using System.Runtime.InteropServices;


public partial class Voxel : StaticBody3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
        // Create a new SurfaceTool
        // Begin generating the mesh
        var st = new SurfaceTool();
        st.Begin(Mesh.PrimitiveType.Triangles);
        st.SetColor(new Color(1, 0, 0));
        st.SetUV(new Vector2(0, 0));
        st.AddVertex(new Vector3(0, 0, 0));

        // Create a new mesh and assign the generated surface to it
        Mesh voxelMesh = st.Commit();

        // Create a MeshInstance node

        MeshInstance3D voxelMeshInstance = new()
        {
            Mesh = voxelMesh
        };

        // Attach the MeshInstance to the voxel
        AddChild(voxelMeshInstance);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
