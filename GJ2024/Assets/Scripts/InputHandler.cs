using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Inventory inventory;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //leftclick
        if (Input.GetMouseButtonDown(0))
        {
            //check item

/*            switch (inventory.itemsInInventory[inventory.slotNumber].ItemNumber)
            {
                case 0:
                    {
                        break;
                    }
                default:
                    break;
            }*/
        }

        //rightclick
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(inventory.itemInSlot);
        }
    }
}
