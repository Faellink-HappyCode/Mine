using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    private int cubeState;

    public GameObject dirtyCube;
    public GameObject grassCube;
    public GameObject stone1Cube;
    public GameObject stone2Cube;
    public GameObject gravelCube;
    public GameObject treeTrunkCube;
    public GameObject treeLeavesCube;
    public GameObject glassCube;
    public GameObject casteBlockCube;
    public GameObject goldCube;
    
    // Start is called before the first frame update
    void Start()
    {
        cubeState = -3;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyCubes();
        ChooseCubeByKey();
        TestingCubeCreation();
    }

    void DestroyCubes()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit,3))
            {
                float dor = Vector3.Dot(transform.up, hit.normal);
                if (hit.transform.gameObject.tag == "cube")
                {
                    Destroy(hit.transform.gameObject);
                }
            }

        }
    }

    void ChooseCubeByKey()
    {
        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKey("" + i))
            {
                cubeState = i;
                break;
            }
        }
    }

    public int ReturnCubeState()
    {
        return this.cubeState;
    }

    public void TestingCubeCreation()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 6f))
            {
                float dot = Vector3.Dot(transform.up, hit.normal);
                Vector3 position = hit.transform.position + hit.normal;
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                GameObject Placement;
                if (cubeState == 1)
                {
                    Placement = Instantiate(dirtyCube, position, rotation) as GameObject;
                }else if (cubeState == 2)
                {
                    Placement = Instantiate(grassCube, position, rotation) as GameObject;
                }
                else if (cubeState == 3)
                {
                    Placement = Instantiate(stone1Cube, position, rotation) as GameObject;
                }
                else if (cubeState == 4)
                {
                    Placement = Instantiate(stone2Cube, position, rotation) as GameObject;
                }
                else if (cubeState == 5)
                {
                    Placement = Instantiate(gravelCube, position, rotation) as GameObject;
                }
                else if (cubeState == 6)
                {
                    Placement = Instantiate(treeTrunkCube, position, rotation) as GameObject;
                }
                else if (cubeState == 7)
                {
                    Placement = Instantiate(treeLeavesCube, position, rotation) as GameObject;
                }
                else if (cubeState == 8)
                {
                    Placement = Instantiate(casteBlockCube, position, rotation) as GameObject;
                }else if (cubeState == 9)
                {
                    Placement = Instantiate(goldCube, position, rotation) as GameObject;
                }
            }
            
        }
    }
}
