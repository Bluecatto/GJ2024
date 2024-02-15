using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemContent : MonoBehaviour
{
    public TextMeshProUGUI itemsAmount;
    public int itemAmount;
    public int ItemNumber;
    public bool canDestroy = true;
    [Header("1.carrot 2.corn 3.tomato 4.pumpking 5.eggplant")]
    [SerializeField] private List<Sprite> inventoryItemsIcons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(itemAmount <= 0 && canDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetupItem(int ItemNumbah, int itemAmounts)
    {
        ItemNumber = ItemNumbah;
        itemAmount = itemAmounts;

        if (itemAmount == 1)
        {
            itemsAmount.text = "";
        }
        else
        {
            itemsAmount.text = itemAmount.ToString();
        }
        GetComponent<Image>().sprite = inventoryItemsIcons[ItemNumber];
    }

    public void UpdateItem(int AmountToAdd)
    {
        itemAmount += AmountToAdd;
        if(itemAmount == 1)
        {
            itemsAmount.text = "";
        }
        else
        {
            itemsAmount.text = itemAmount.ToString();
        }
    }

    public void SetItem(int totalNumber, int bucket)
    {
        itemAmount = totalNumber;
        if (itemAmount == 0)
        {
            SetupItem(bucket, 0);
        }
        else
        {
            itemsAmount.text = itemAmount.ToString();
        }
    }
}
