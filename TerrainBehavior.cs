using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBehavior : MonoBehaviour
{

    public GameObject terrainPrefab;

    public int xSize;

    public int i = 0;

    public float perlin1;
    public float perlin2;

    public float multi;


    public float a;
    public float b;
    public float c;
    public float d;

    public GameObject terrain2;

    // Start is called before the first frame update
    void Start()
    {
        Mine();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    Mine();
        //}
        
        
    }


    void Mine()
    {
        GameObject terrain = Instantiate(terrainPrefab);
        terrain.GetComponent<TerrainGenerator>().CreateMesh(xSize, xSize, i , i, perlin1, perlin2, multi);
        terrain.transform.position = new Vector3(0, 0, 0);

        terrain2 = Instantiate(terrainPrefab);
        terrain2.GetComponent<TerrainGenerator>().CreateMesh(xSize, xSize, 2, 2, perlin1, perlin2, multi);
        terrain2.transform.position = new Vector3(0, 405.6f, xSize);
        terrain2.transform.rotation = new Quaternion(1 ,0 ,0 ,0);



    }
}
