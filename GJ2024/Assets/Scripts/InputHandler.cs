using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> crops;
    private GameObject crop;

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
            if(inventory.itemsInInventory[inventory.slotNumber - 1] != null)
            {
                switch (inventory.itemsInInventory[inventory.slotNumber - 1].ItemNumber)
                {
                    case 6:
                        {
                            SeedPlant(0);
                            break;
                        }
                    case 7:
                        {
                            SeedPlant(1);
                            break;
                        }
                    case 8:
                        {
                            SeedPlant(2);
                            break;
                        }
                    case 9:
                        {
                            SeedPlant(3);
                            break;
                        }
                    case 10:
                        {
                            SeedPlant(4);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        //rightclick
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "FarmLand")
                {
                    FarmlandScript farmland = hit.collider.GetComponent<FarmlandScript>();
                    if (farmland.hasPlant)
                    {
                        Crops crop = farmland.attachedCrop.GetComponent<Crops>();
                        crop.Harvest();

                        if (!crop.canRegrow)
                        {
                            farmland.hasPlant = false;
                        }

                        if (crop.isDead)
                        {
                            farmland.hasPlant = false;
                        }
                    }
                }
            }
        }
    }

    private void SeedPlant(int seed)
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "FarmLand")
            {
                FarmlandScript farmland = hit.collider.GetComponent<FarmlandScript>();
                if (!farmland.hasPlant)
                {
                    farmland.hasPlant = true;
                    //inventory.itemsInInventory[inventory.slotNumber - 1].itemAmount--;
                    inventory.itemsInInventory[inventory.slotNumber - 1].UpdateItem(-1);
                    crop = Instantiate(crops[seed], hit.transform);
                    farmland.attachedCrop = crop;
                }
            }
        }
    }
}
