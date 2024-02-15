using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class InputHandler : MonoBehaviour
{
    public Inventory inventory;
    public List<GameObject> crops;
    public GameObject crop;
    public FarmlandManager farm;

    private float AttackCooldownTimer;
    public AudioSource waterGet, waterUse, cropGet, plantSeed, swordSwing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.itemsInInventory[inventory.slotNumber - 1] != null)
        {
            if (inventory.itemsInInventory[inventory.slotNumber - 1].ItemNumber == 17)
            {

            }
        }

        //leftclick
        if (Input.GetMouseButtonDown(0))
        {
            if (inventory.itemsInInventory[inventory.slotNumber - 1] != null)
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
                    case 11:
                        {
                            PlayerAttack(5f, 0.425f);
                            break;
                        }
                    case 12:
                        {
                            PlayerAttack(12.5f, 0.85f);
                            break;
                        }
                    case 14:
                        {
                            //waterbucket
                            WaterDirt(0);
                            break;
                        }
                    case 16:
                        {
                            //waterbucket
                            WaterDirt(1);
                            break;
                        }
                    case 17:
                        {
                            //hoe
                            farm.SpawnThing();
                            break;
                        }
                    case 18:
                        {
                            //hoe
                            farm.SpawnThing();
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
                        if (farmland.attachedCrop.GetComponent<Crops>() != null)
                        {
                            Crops crop = farmland.attachedCrop.GetComponent<Crops>();

                            if (!crop.canRegrow)
                            {
                                farmland.hasPlant = false;
                            }

                            if (crop.isDead)
                            {
                                farmland.hasPlant = false;
                            }

                            if (crop.plantLevel != crop.maxlevel)
                            {
                                farmland.hasPlant = false;
                            }

                            crop.Harvest();
                            farmland.SetDry();
                            cropGet.Play();
                        }
                    }
                }

                if (hit.collider.tag == "WaterSource")
                {
                    //check if using bucket 13,14,15,16
                    if (inventory.itemsInInventory[inventory.slotNumber - 1] != null)
                    {
                        if (inventory.itemsInInventory[inventory.slotNumber - 1].ItemNumber == 13 || inventory.itemsInInventory[inventory.slotNumber - 1].ItemNumber == 14)
                        {
                            inventory.itemsInInventory[inventory.slotNumber - 1].SetupItem(14, 4);
                            waterGet.Play();
                        }
                        if (inventory.itemsInInventory[inventory.slotNumber - 1].ItemNumber == 15 || inventory.itemsInInventory[inventory.slotNumber - 1].ItemNumber == 16)
                        {
                            inventory.itemsInInventory[inventory.slotNumber - 1].SetupItem(16, 8);
                            waterGet.Play();
                        }
                    }
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (AttackCooldownTimer >= 0f)
        {
            AttackCooldownTimer -= Time.deltaTime;
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
                    inventory.itemsInInventory[inventory.slotNumber - 1].UpdateItem(-1);
                    crop = Instantiate(crops[seed], hit.transform);

                    plantSeed.Play();

                    farmland.attachedCrop = crop;
                    if (farmland.isWet)
                    {
                        Crops crop1 = farmland.attachedCrop.GetComponent<Crops>();
                        crop1.StartGrow();
                    }
                }
            }
        }
    }

    private void WaterDirt(int buckettype)
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "FarmLand")
            {
                if (inventory.itemsInInventory[inventory.slotNumber - 1].itemAmount >= 1)
                {
                    FarmlandScript farmland = hit.collider.GetComponent<FarmlandScript>();

                    farmland.SetWet();
                    waterUse.Play();

                    inventory.itemsInInventory[inventory.slotNumber - 1].canDestroy = false;
                    inventory.itemsInInventory[inventory.slotNumber - 1].UpdateItem(-1);
                }

                if (inventory.itemsInInventory[inventory.slotNumber - 1].itemAmount == 0)
                {
                    if (buckettype == 0)
                    {
                        inventory.itemsInInventory[inventory.slotNumber - 1].SetupItem(13, 0);
                    }
                    else if (buckettype == 1)
                    {
                        inventory.itemsInInventory[inventory.slotNumber - 1].SetupItem(15, 0);
                    }
                }
            }
        }
    }

    //this is BAD !!!!!!!!!!!!!!!!!!!!!!!!!!
    public void PlayerAttack(float damage, float cooldown)
    {
        if (AttackCooldownTimer < 0f)
        {
            //TODO: Swing animation.
            //Debug.Log($"Player swings sword");
            swordSwing.Play();
            AttackCooldownTimer = cooldown;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject[] target = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < target.Length; i++)
            {
                if (Vector3.Distance(target[i].transform.position, player.transform.position) <= 2.5f)
                {
                    target[i].GetComponent<EnemyController>().TakeDamage(damage);
                    target[i].GetComponent<NavMeshAgent>().velocity += Vector3.ClampMagnitude((target[i].transform.position - player.transform.position) * 20f, 4f);
                    //Debug.Log($"dealt {damage} damage to {target[i].name}");
                }
            }
        }
    }
}
