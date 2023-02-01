using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUI : MonoBehaviour
{
    [SerializeField] MenuManager mm;

    private Transform bg;
    private Transform upgradeButtonTemplate;

    [SerializeField] GameObject buyFailSound;

    private void Awake()
    {
        bg = transform.Find("Buy Menu Background");
        upgradeButtonTemplate = bg.Find("Upgrade Button Template");
        upgradeButtonTemplate.gameObject.SetActive(false);
    }
    
    /*
    private void CreateUpgradeButton(string itemName, int itemCost)
    {
        Transform upgradeButtonTransform = Instantiate(upgradeButtonTemplate, bg);
        RectTransform upgradeButtonRectTransform = upgradeButtonTransform.GetComponent<RectTransform>();

        Vector2 buttonPosition = 



        upgradeButtonTransform
    }*/

    private void TryBuyItem(Item.ItemType item)
    {
        if (mm.TrySpendFavor(Item.GetCost(item)))
        {
            mm.BoughtItem(item);
        }

        else
        {
            buyFailSound.GetComponent<AudioSource>().Play();
        }
    }
}
