using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    public List<GameObject> objectsList;
    private int cubeState;
    public int ReturnCubeState()
    {
        return this.cubeState;
    }

    // Start is called before the first frame update
    void Start()
    {
        cubeState = 1;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyCubes();
        ChooseCubeByKey();
        CreateCubes();
    }

    public void DestroyCubes()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 3))
            {
                float dot = Vector3.Dot(transform.up, hit.normal);

                if (hit.transform.gameObject.CompareTag("Cube"))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }

    }

    public void ChooseCubeByKey()
    {
        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown("" + i))
            {
                cubeState = i;
                break;
            }
        }
    }

    public void CreateCubes()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 6))
            {
                float dot = Vector3.Dot(transform.up, hit.normal);
                Vector3 position = hit.transform.position + hit.normal;
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

                if (objectsList[cubeState] != null)
                {
                    GameObject Placement = Instantiate(objectsList[cubeState], position, rotation) as GameObject;
                    Placement.tag = "Cube";
                }
            }
        }
    }
}
