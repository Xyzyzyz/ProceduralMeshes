using Unity.Mathematics;
using UnityEngine;

using static Unity.Mathematics.math;

namespace ProceduralMeshes.Generators {
	public struct SharedSquareGrid : IMeshGenerator {

		public int VertexCount => (Resolution + 1) * (Resolution + 1);
		public int IndexCount => 6 * Resolution * Resolution;
		public int Resolution { get; set; }

		public Bounds Bounds => new Bounds(Vector3.zero, new Vector3(1f, 0f, 1f));
		public int JobLength => Resolution + 1;

		public void Execute<S> (int z, S streams) where S : struct, IMeshStreams {
			
			int vi = (Resolution + 1) * z; // First vertex in the row

			Vertex vertex = new Vertex();
			vertex.normal.y = 1f;
			vertex.tangent.xw = float2(1f, -1f);

			vertex.position.x = -0.5f;
			vertex.position.z = (float)z / Resolution - 0.5f;
			vertex.texCoord0.y = (float)z / Resolution;

			streams.SetVertex(vi, vertex);
			vi += 1;

			for (int x = 1; x <= Resolution; x++, vi++) {
				vertex.position.x = (float)x / Resolution - 0.5f;
				vertex.texCoord0.x = (float)x / Resolution;
				streams.SetVertex(vi, vertex);
			}

		}

	}
}