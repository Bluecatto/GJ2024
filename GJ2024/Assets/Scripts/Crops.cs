using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    [Header("1.carrot 2.corn 3.tomato 4.pumpking 5.eggplant")]
    public int plantnumber = 1;
    public Material DeadMat;

    public int plantLevel = 0;
    public int maxlevel = 5;
    public int timeToDie = 5;

    public bool canRegrow = true;
    public bool isDead = false;
    public int goBackToLevel = 3;

    public MeshRenderer mesh;
    private bool isupgrading = false;
    [SerializeField] List<Material> mats;
    [SerializeField] List<int> delay;

    public Inventory inv;

    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.FindWithTag("DevCube").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Harvest();
        }
    }

    private void FixedUpdate()
    {
        if (!isupgrading && plantLevel <= maxlevel - 1 && !isDead)
        {
            CancelInvoke("KillPlant");
            isupgrading = true;
            Invoke("UpgradeCrop", delay[plantLevel] + Random.Range(.1f, 5f));
        }
    }

    public void UpgradeCrop()
    {
        mesh.material = mats[plantLevel];
        plantLevel++;
        isupgrading = false;
        if(plantLevel == maxlevel)
        {
            Invoke("KillPlant", timeToDie);
        }
    }

    public void Harvest()
    {
        if(plantLevel == maxlevel)
        {
            //1.carrot 2.corn 3.tomato 4.pumpking 5.eggplant
            switch (plantnumber)
            {
                case 1:
                    {
                        inv.AddItem(1, Random.Range(2, 5));
                        break;
                    }
                case 2:
                    {
                        inv.AddItem(2, Random.Range(3, 5));
                        break;
                    }
                case 3:
                    {
                        inv.AddItem(3, Random.Range(4, 7));
                        break;
                    }
                case 4:
                    {
                        inv.AddItem(4, Random.Range(1, 3));
                        break;
                    }
                case 5:
                    {
                        inv.AddItem(5, Random.Range(1, 4));
                        break;
                    }
                default:
                    break;
            }

            if (canRegrow)
            {
                plantLevel = goBackToLevel;
                mesh.material = mats[plantLevel];
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void KillPlant()
    {
        isDead = true;
        mesh.material = DeadMat;
        plantLevel = 0;
    }
}
