using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject Ui, Selector, mainItem;
    [SerializeField] public List<GameObject> Slots;
    private bool isUiOpen = false;
    public int slotNumber = 1;
    public int itemInSlot = 0;

    [Header("1.carrot 2.corn 3.tomato 4.pumpking 5.eggplant")]
    public List<int> MaxAmount;

    private GameObject TempItem;
    private ItemContent currentItem;
    public List<ItemContent> itemsInInventory;
    public List<bool> isSlotOccupied;

    // Start is called before the first frame update
    void Start()
    {
        //AddItem(4, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isUiOpen)
            {
                Ui.SetActive(false);
                isUiOpen = false;
            }
            else
            {
                Ui.SetActive(true);
                isUiOpen = true;
            }
        }

        //aaaaaaaaaaaaaaaaaaaaaaaaaaaaa
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetSelector(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetSelector(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetSelector(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetSelector(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetSelector(5);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            if (slotNumber >= 5)
            {

            }
            else
            {
                SetSelector(slotNumber + 1);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(slotNumber <= 1)
            {

            }
            else
            {
                SetSelector(slotNumber - 1);
            }
        }
    }

    public void AddItem(int itemnumber, int itemAmount)
    {
        for (int i = 0; i < itemsInInventory.Count; i++)
        {
            if (itemsInInventory[i] != null)
            {
                if (itemsInInventory[i].ItemNumber == itemnumber)
                {
                    int total = itemsInInventory[i].itemAmount + itemAmount;

                    if (total <= MaxAmount[itemnumber])
                    {
                        itemsInInventory[i].UpdateItem(itemAmount);
                        return;
                    }
                    else
                    {
                        int amountToAdd = MaxAmount[itemnumber] - itemsInInventory[i].itemAmount;
                        itemsInInventory[i].UpdateItem(amountToAdd);
                        itemAmount -= amountToAdd;
                    }
                }
            }
        }

        if (itemAmount > 0)
        {
            for (int i = 0; i < itemsInInventory.Count; i++)
            {
                if (itemsInInventory[i] == null)
                {
                    TempItem = Instantiate(mainItem, Slots[i].transform);
                    currentItem = TempItem.GetComponent<ItemContent>();
                    currentItem.SetupItem(itemnumber, itemAmount);
                    itemsInInventory.Insert(i, currentItem);
                    break;
                }
            }
        }
    }

    private void SetSelector(int number)
    {
        if (itemsInInventory[number] != null)
        {
            itemInSlot = itemsInInventory[number].ItemNumber;
        }
        slotNumber = number;
        Selector.transform.position = Slots[number - 1].transform.position;
    }

    public void CloseMenu()
    {
        Ui.SetActive(false);
        isUiOpen = false;
    }
}
