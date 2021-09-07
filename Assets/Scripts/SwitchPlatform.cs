using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPlatform : MonoBehaviour
{
    public int weaponType = 0;
    private bool isScrolling = false;
    private bool isScrollingDown = false;

    [SerializeField] private Sprite[] spriteList;

    private void Switch()
    {
        if (isScrollingDown) weaponType = (weaponType + 1) % spriteList.Length;
        else
        {
            if (weaponType == 0) weaponType = spriteList.Length;
            else weaponType = (weaponType - 1) % spriteList.Length;
        }
        this.gameObject.GetComponent<Image>().sprite = spriteList[weaponType];
    }

    void Update()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            isScrolling = true;

            if (Input.mouseScrollDelta.y < 0) isScrollingDown = true;
            else isScrollingDown = false;
        }

        else
        {
            if (isScrolling)
            {
                Switch();
                isScrolling = false;
            }
        }
    }
}