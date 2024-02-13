using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject Ui, Selector, mainItem;
    [SerializeField] private List<GameObject> Slots;
    private bool isUiOpen = false;
    private int slotNumber = 1;

    private GameObject TempItem;
    private ItemContent currentItem;
    public List<ItemContent> itemsInInventory;
    public List<bool> isSlotOccupied;

    // Start is called before the first frame update
    void Start()
    {
        AddItem(1, 42);
        //AddItem(4, 16);
        //AddItem(4, 1);
        //AddItem(2, 6);
        //AddItem(3, 1);
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
            if (itemsInInventory[i] == null)
            {
                TempItem = Instantiate(mainItem, Slots[i].transform);
                currentItem = TempItem.GetComponent<ItemContent>();
                currentItem.SetupItem(itemnumber, itemAmount);
                itemsInInventory.Insert(i, currentItem);
                break;
            }
            else
            {
                Debug.Log("Slot Full!");
            }
            if(i == 3)
            {
                Debug.Log("Inventory Full!");
            }
        }
    }

    private void SetSelector(int number)
    {
        slotNumber = number;
        Selector.transform.position = Slots[number - 1].transform.position;
    }

    public void CloseMenu()
    {
        Ui.SetActive(false);
        isUiOpen = false;
    }
}
