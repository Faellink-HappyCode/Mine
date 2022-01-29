using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDScript : MonoBehaviour
{

    public GameObject panel;
    public BlocksOptions blockOptions;
    public BlockManager blockManager;
    public GameObject marker;
    public int imageNumber;
    private Image _image;
    
    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateMarker()
    {
        if (blockManager.ReturnCubeState() == imageNumber)
        {
            marker.SetActive(true);
        }
        else
        {
            marker.SetActive(false);
        }
    }
}
