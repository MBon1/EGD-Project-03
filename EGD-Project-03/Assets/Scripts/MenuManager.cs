using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject buyMenu, titleTexts;
    [SerializeField] GameObject upgradeSound;
    [SerializeField] GameObject upgradeParticles;
    [SerializeField] GameObject grinder, funnel;
    [SerializeField] GameObject sSpeedButton, mpsButton, gSizeButton, favorButton, fSizeButton;
    [SerializeField] SheepSpawner spawner;
    [SerializeField] Text favorText, favorText2;
    
    Vector2 mousePos;

    public event EventHandler OnFavorAmountChanged;

    private int favorAmount, favorGain = 10, meatRate = 2, upgradesPurchased = 0;

    void Start()
    {
        mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void Update()
    {
        // disables title text after any mouse movement
        if (titleTexts.activeSelf)
        {
            if ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) != mousePos)
            {
                titleTexts.SetActive(false);
            }
        }

        mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);      

        /*
        if (Input.GetButtonDown("Fire1"))
        {
            BuyMenu();
        }*/
    }

    public int GetMeatRate()
    {
        return meatRate;
    }

    public void MeatCollected()
    {
        favorAmount += favorGain + UnityEngine.Random.Range(0, favorGain + favorGain/2);
        favorText.text = favorAmount.ToString();
        favorText2.text = favorAmount.ToString();
    }

    public void SpawnSpeedUpgrade()
    {
        spawner.spawnRate = 2 * spawner.spawnRate;
        sSpeedButton.SetActive(false);
    }

    public void MPSUpgrade()
    {
        Instantiate(upgradeParticles, new Vector3(-6.5f, 3.5f, 0f), Quaternion.identity);
        meatRate = meatRate + 2;
        mpsButton.SetActive(false);
    }

    public void GrinderSizeUpgrade()
    {
        Instantiate(upgradeParticles, new Vector3(-6.5f, 3.5f, 0f), Quaternion.identity);
        grinder.transform.localScale = new Vector3(grinder.transform.localScale.x * 1.6f, grinder.transform.localScale.y, grinder.transform.localScale.z);
        gSizeButton.SetActive(false);
    }

    public void FavorUpgrade()
    {
        Instantiate(upgradeParticles, new Vector3(6.81f, -4f, 0f), Quaternion.identity);
        favorGain = favorGain * 2;
        favorButton.SetActive(false);
    }

    public void FunnelSizeUpgrade()
    {
        Instantiate(upgradeParticles, new Vector3(6.81f, -4f, 0f), Quaternion.identity);
        funnel.transform.localScale = new Vector3(funnel.transform.localScale.x * 1.6f, funnel.transform.localScale.y, funnel.transform.localScale.z);
        fSizeButton.SetActive(false);
    }

    public void BuyMenu()
    {
        buyMenu.SetActive(!buyMenu.activeSelf);
    }

    public void BoughtItem(Item.ItemType item)
    {
        upgradeSound.GetComponent<AudioSource>().Play();
        Instantiate(upgradeParticles, new Vector3(mousePos.x, mousePos.y, 0f), Quaternion.identity);
        Debug.Log("bought");
        if (item == Item.ItemType.SpawnSpeed)
        {
            SpawnSpeedUpgrade();
        }
        else if (item == Item.ItemType.MPS)
        {
            MPSUpgrade();
        }
        else if (item == Item.ItemType.GrinderSize)
        {
            GrinderSizeUpgrade();
        }
        else if (item == Item.ItemType.Favor)
        {
            FavorUpgrade();
        }
        else if (item == Item.ItemType.FunnelSize)
        {
            FunnelSizeUpgrade();
        }

        /*
        switch (item)
        {
            default:
            case Item.ItemType.SpawnSpeed:      ;    break;
            case Item.ItemType.MPS:             MPSUpgrade();           break;
            case Item.ItemType.GrinderSize:     GrinderSizeUpgrade();   break;
            case Item.ItemType.Favor:           FavorUpgrade();         break;
            case Item.ItemType.FunnelSize:      FunnelSizeUpgrade();    break;
            // case Item.ItemType.GrinderSize:     GrinderSizeUpgrade();   break;

        }*/

        upgradesPurchased++;
        if (upgradesPurchased >= 5)
        {
            // cool
        }
        
    }

    public bool TrySpendFavor(int favor)
    {
        if (favorAmount > favor)
        {
            favorAmount -= favor;
            favorText.text = favorAmount.ToString();
            favorText2.text = favorAmount.ToString();
            OnFavorAmountChanged?.Invoke(this, EventArgs.Empty);
            return true;
        }
           
        return false;
    }
}
