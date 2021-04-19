using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

   


    private void Start()
    {

    }

    public void CreateMesh(int zSize, int xSize, float perlinOffsetZ, float perlinOffsetX, float  perlinMulti1, float perlinMulti2, float perlinStrength)
    {
        Mesh mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        //Set vertices only adjusting the height with perlin noise
        Vector3[] vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(z * .001f, x * .001f) * 200;
                y += Mathf.PerlinNoise(z * .01f, x * .01f) * 100;
                y += Mathf.PerlinNoise(z * .03f, x * .03f) * 20;
                y += Mathf.PerlinNoise(z * .04f, x * .04f) * 1;
                y += Mathf.PerlinNoise(z * .05f, x * .05f) * 1;
                y += Mathf.PerlinNoise(z * .2f, x * .2f) * 1;
                y += Mathf.PerlinNoise(z * 8.3f, x * 8.3f) * .1f;
                //float y = Mathf.PerlinNoise((z + (perlinOffsetZ * zSize)) * perlinMulti1, (x + (perlinOffsetX * xSize)) * perlinMulti2) * perlinStrength;
                //y += Mathf.PerlinNoise(z * .03f + perlinOffsetY, x * .03f + perlinOffsetY) * perlinMulti2;
                //y += Mathf.PerlinNoise(z * .4f, x * .4f) * 2;

                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }

        int[] triangles = new int[xSize * zSize * 6];
        int tris = 0;
        int vert = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("coll");
    }
}
