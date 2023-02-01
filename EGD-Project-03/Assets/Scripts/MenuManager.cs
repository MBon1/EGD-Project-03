using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject buyMenu;
    [SerializeField] GameObject upgradeSound;

    public event EventHandler OnFavorAmountChanged;

    private int favorAmount;

    void Update()
    {
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            BuyMenu();
        }*/
    }



    public void SpawnSpeedUpgrade()
    {
        return;
    }

    public void MPSUpgrade()
    {
        return;
    }

    public void GrinderSizeUpgrade()
    {
        return;
    }

    public void FavorUpgrade()
    {
        return;
    }

    public void FunnelSizeUpgrade()
    {
        return;
    }

    public void BuyMenu()
    {
        buyMenu.SetActive(!buyMenu.activeSelf);
    }

    public void BoughtItem(Item.ItemType item)
    {
        upgradeSound.GetComponent<AudioSource>().Play();
        Debug.Log("bought");
        switch (item)
        {
            default:
            case Item.ItemType.MPS:      MPSUpgrade();   break;
        }
        
    }

    public bool TrySpendFavor(int favor)
    {
        if (favorAmount > favor)
        {
            favorAmount -= favor;
            OnFavorAmountChanged?.Invoke(this, EventArgs.Empty);
            return true;
        }
           
        return false;
    }
}
