using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shopScript : MonoBehaviour
{
    public GameObject ShopUi;
    public Inventory inv;

    public List<int> ItemID;

    public List<TextMeshProUGUI> AmountText;

    public List<int> sellAmount;
    public List<int> sellItemAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ShopUi.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ShopUi.SetActive(false);
        }
    }

    public void Up(int i)
    {
        sellAmount[i]++;
        AmountText[i].text = sellAmount[i].ToString();
    }
    public void Down(int i)
    {
        if(sellAmount[i] >= 2)
        {
            sellAmount[i]--;
            AmountText[i].text = sellAmount[i].ToString();
        }
    }

    public void Sell(int itemid)
    {
        int itemNumberToSell = ItemID[itemid];
        int sellPrice = sellItemAmount[itemid];
        int sellCount = sellAmount[itemid];
        int totalPrice = sellPrice * sellCount;

        if (inv.itemsInInventory != null)
        {
            int itemIndex = inv.itemsInInventory.FindIndex(item => item != null && item.ItemNumber == itemNumberToSell && item.itemAmount >= sellCount);
            if (itemIndex != -1)
            {
                inv.RemoveItem(itemNumberToSell, sellCount);
                inv.SetGold(totalPrice);
                return;
            }
        }
        Debug.Log("Not enough items to sell.");
    }

    public void Buy(int itemid)
    {
        int cost = sellItemAmount[itemid] * sellAmount[itemid];

        if (cost <= inv.gold)
        {
            inv.AddItem(ItemID[itemid], sellAmount[itemid]);
            inv.SetGold(-cost);
        }
        else
        {
            Debug.Log("no Munnie");
        }
    }
}
