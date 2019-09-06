using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class GridMesh : MonoBehaviour
{
    public int xSize, ySize;
    private Vector3[] _vertices;



    void Awake()
    {
        Generate();
    }

    void Generate()
    {
        #region vertices
        int verticesCount = (xSize + 1) * (ySize + 1);
        _vertices = new Vector3[verticesCount];
        Vector2 [] uv=new Vector2[verticesCount];
        for (int i = 0, k = 0; i < ySize + 1; i++)
        {
            for (var j = 0; j < xSize + 1; j++, k++)
            {
                _vertices[k] = new Vector3(j, i, 0);
                uv[k]=new Vector2(j/(float)xSize,i/(float)ySize);
            }
        }
        #endregion

        #region tris
        int[] tris = new int[6 * xSize * ySize];
        for (int j = 0,k=0; j < ySize; j++)
        {
            for (int i = 0; i < xSize; i++,k++ )
            {
                int triIndexBase = k * 6;
                int vertexIndexBase = j*(xSize+1)+i;

                tris[triIndexBase] = vertexIndexBase;
                tris[triIndexBase + 1] = tris[triIndexBase + 3] = vertexIndexBase + xSize + 1;
                tris[triIndexBase + 2] = tris[triIndexBase + 5] = vertexIndexBase + 1;
                tris[triIndexBase + 4] = vertexIndexBase + xSize + 2;
            }

        }

        #endregion






        Mesh mesh = new Mesh();
        mesh.name = "grid mesh";
        mesh.vertices = _vertices;
        mesh.triangles = tris;
        mesh.uv = uv;
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;


    }

    private void OnDrawGizmos()
    {
        if (_vertices == null)
        {
            return;
        }

        Gizmos.color = Color.black;
        foreach (var vertex in _vertices)
        {
            Gizmos.DrawSphere(transform.TransformPoint(vertex), 0.1f);
        }
    }
}
