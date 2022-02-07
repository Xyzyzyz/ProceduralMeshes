using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class SimpleProceduralMesh : MonoBehaviour {

	void OnEnable () {
		Mesh mesh = new Mesh {
			name = "Procedural Mesh"
		};

		mesh.vertices = new Vector3[] {
			Vector3.zero, Vector3.right, Vector3.up, new Vector3(1f, 1f, 0f) // Vertex positions
		};

		mesh.normals = new Vector3[] {
			Vector3.back, Vector3.back, Vector3.back, Vector3.back // Vertex normal vectors (if you were standing on the surface of a triangle, what vector would represent your local up?)
		};

		mesh.tangents = new Vector4[] {
			new Vector4(1f, 0f, 0f, -1f), // Vertex tangent vectors - "local right", fourth vector determines whether "local forward" is positive or negative
			new Vector4(1f, 0f, 0f, -1f),
			new Vector4(1f, 0f, 0f, -1f),
			new Vector4(1f, 0f, 0f, -1f)
		};

		mesh.uv = new Vector2[] {
			Vector2.zero, Vector2.right, Vector2.up, Vector2.one // UV Coordinates per vertex - 2d points on base map, normalized to 0-1 range
		};

		mesh.triangles = new int[] {
			0, 2, 1, 1, 2, 3 // Indices of vertex positions
		};

		GetComponent<MeshFilter>().mesh = mesh;
	}
}