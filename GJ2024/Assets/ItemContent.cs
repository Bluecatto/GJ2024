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
    [SerializeField] private List<Sprite> inventoryItemsIcons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(itemAmount <= 0)
        {
            //remove from list
            Destroy(this.gameObject);
        }
    }

    public void SetupItem(int ItemNumbah, int itemAmounts)
    {
        ItemNumber = ItemNumbah;
        itemAmount = itemAmounts;
        itemsAmount.text = itemAmount.ToString();
        GetComponent<Image>().sprite = inventoryItemsIcons[ItemNumber];
    }

    public void UpdateItem(int AmountToAdd)
    {
        itemAmount += AmountToAdd;
        itemsAmount.text = itemAmount.ToString();
    }
}
