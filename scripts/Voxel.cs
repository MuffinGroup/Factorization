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
        SurfaceTool st = new SurfaceTool();
        
        // Begin generating the mesh
        st.Begin(Mesh.PrimitiveType.Triangles);
        
        // Define the vertices of the voxel cube
        st.AddVertex(new Vector3(-0.5f, -0.5f, -0.5f));
        st.AddVertex(new Vector3(0.5f, -0.5f, -0.5f));
        st.AddVertex(new Vector3(-0.5f, 0.5f, -0.5f));
        st.AddVertex(new Vector3(0.5f, 0.5f, -0.5f));
        st.AddVertex(new Vector3(-0.5f, -0.5f, 0.5f));
        st.AddVertex(new Vector3(0.5f, -0.5f, 0.5f));
        st.AddVertex(new Vector3(-0.5f, 0.5f, 0.5f));
        st.AddVertex(new Vector3(0.5f, 0.5f, 0.5f));
        
        // Define the indices to form triangles
        st.AddIndex(0);
        st.AddIndex(2);
        st.AddIndex(1);
        st.AddIndex(1);
        st.AddIndex(2);
        st.AddIndex(3);
        // ... continue adding indices for all triangles
        
        // Generate normals and UV coordinates if needed
        st.GenerateNormals();
        st.GenerateTangents();
        st.SetUV(new Vector2(0, 0));

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
