using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject buyMenu;

    void Update()
    {
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            BuyMenu();
        }*/
    }

    public void BuyMenu()
    {
        buyMenu.SetActive(!buyMenu.activeSelf);
    }
}
