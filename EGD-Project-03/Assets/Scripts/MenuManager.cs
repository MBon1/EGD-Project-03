using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject buyMenu;
    [SerializeField] GameObject upgradeSound;
    [SerializeField] GameObject upgradeParticles;
    [SerializeField] GameObject spawner, grinder, funnel;
    [SerializeField] GameObject sSpeedButton, mpsButton, gSizeButton, favorButton, fSizeButton;

    public event EventHandler OnFavorAmountChanged;

    private int favorAmount, favorGain = 10, upgradesPurchased = 0;

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
        // todo
        sSpeedButton.SetActive(false);
    }

    public void MPSUpgrade()
    {
        // todo
        mpsButton.SetActive(false);
    }

    public void GrinderSizeUpgrade()
    {
        grinder.transform.localScale = new Vector3(grinder.transform.localScale.x * 1.3f, grinder.transform.localScale.y, grinder.transform.localScale.z);
        gSizeButton.SetActive(false);
    }

    public void FavorUpgrade()
    {
        favorGain = favorGain * 2;
        favorButton.SetActive(false);
    }

    public void FunnelSizeUpgrade()
    {
        funnel.transform.localScale = new Vector3(funnel.transform.localScale.x * 1.3f, funnel.transform.localScale.y, funnel.transform.localScale.z);
        fSizeButton.SetActive(false);
    }

    public void BuyMenu()
    {
        buyMenu.SetActive(!buyMenu.activeSelf);
    }

    public void BoughtItem(Item.ItemType item)
    {
        upgradeSound.GetComponent<AudioSource>().Play();
        Instantiate(upgradeParticles, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        Debug.Log("bought");
        switch (item)
        {
            default:
            case Item.ItemType.SpawnSpeed:      SpawnSpeedUpgrade();    break;
            case Item.ItemType.MPS:             MPSUpgrade();           break;
            case Item.ItemType.GrinderSize:     GrinderSizeUpgrade();   break;
            case Item.ItemType.Favor:           FavorUpgrade();         break;
            case Item.ItemType.FunnelSize:      FunnelSizeUpgrade();    break;
            // case Item.ItemType.GrinderSize:     GrinderSizeUpgrade();   break;

        }

        upgradesPurchased++;
        if (upgradesPurchased >= 6)
        {
            // cool
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
