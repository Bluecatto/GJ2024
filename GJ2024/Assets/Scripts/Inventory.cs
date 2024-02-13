using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject Ui, Selector;
    [SerializeField] private List<GameObject> Slots;
    private bool isUiOpen = false;
    private int slotNumber = 1;
    [SerializeField] private List<GameObject> hotBarItems;
    [SerializeField] private List<bool> hotBaroccupied;
    [SerializeField] private List<GameObject> hotBarItemAmount;

    [SerializeField] private List<GameObject> inventoryItemsIcons;

    // Start is called before the first frame update
    void Start()
    {
        hotBarItems[0] = inventoryItemsIcons[0];
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

    private void SetSelector(int number)
    {
        slotNumber = number;
        Selector.transform.position = Slots[number - 1].transform.position;
    }

    public void CloseMenu()
    {
        Ui.SetActive(false);
    }
}
