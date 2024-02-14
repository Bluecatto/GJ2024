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

    public void Up1()
    {
        sellAmount[1]++;
        AmountText[1].text = sellAmount[1].ToString();
    }
    public void Down1()
    {
        if(sellAmount[1] >= 2)
        {
            sellAmount[1]--;
            AmountText[1].text = sellAmount[1].ToString();
        }
    }
    public void Sell1()
    {

/*        Debug.Log("sell");
        int MoneyToAdd = sellItemAmount[1] * sellAmount[1];
        Debug.Log(MoneyToAdd);
        inv.SetGold(MoneyToAdd);*/
    }

/*    public void Up2()
    {
        sellAmount[2]++;
        AmountText[2].text = sellAmount[2].ToString();
    }
    public void Down2()
    {
        if (sellAmount[2] >= 2)
        {
            sellAmount[2]--;
            AmountText[2].text = sellAmount[2].ToString();
        }
    }
    public void Sell2()
    {
        Debug.Log("sell");
    }

    public void Up3()
    {
        sellAmount[3]++;
        AmountText[3].text = sellAmount[3].ToString();
    }
    public void Down3()
    {
        if (sellAmount[3] >= 3)
        {
            sellAmount[3]--;
            AmountText[3].text = sellAmount[3].ToString();
        }
    }
    public void Sell3()
    {
        Debug.Log("sell");
    }*/
}
