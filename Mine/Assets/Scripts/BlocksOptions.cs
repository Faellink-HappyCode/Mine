using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlocksOptions : MonoBehaviour
{
    public BlockManager blockManager;
    public List<BlockInfo> blockInfos;
    public int key;
    
    private Image _blockImage;
    private int option = -1;

    private void Awake()
    {
        _blockImage = GetComponent<Image>();
    }

    public void ButtonPlus()
    {
        if (option >= 9)
        {
            option = 0;
        }
        else
        {
            option++;
        }
        SelectCube();
    }

    public Sprite GetSprite()
    {
        return _blockImage.sprite;
    }

    public void ButtonLess()
    {
        if (option <= -1)
        {
            option = 9;
        }
        else
        {
            option--;
        }
        SelectCube();
    }
    public void SelectCube()
    {
        if (option < 0 || option > 9)
        {
            _blockImage.sprite = null;
            blockManager.objectsList[key] = null;
        }
        else
        {
            blockManager.objectsList[key] = blockInfos[option].gameObject;
            _blockImage.sprite = blockInfos[option].blockSprite;
        }
    }
}
