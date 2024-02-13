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

    // Start is called before the first frame update
    void Start()
    {

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
                        int i = PlayerPrefs.GetInt("Carrot");
                        PlayerPrefs.SetInt("Carrot", i + Random.Range(3, 5));
                        break;
                    }
                case 2:
                    {
                        int i = PlayerPrefs.GetInt("Corn");
                        PlayerPrefs.SetInt("Corn", i + Random.Range(3, 5));
                        break;
                    }
                case 3:
                    {
                        int i = PlayerPrefs.GetInt("Tomato");
                        PlayerPrefs.SetInt("Tomato", i + Random.Range(3, 5));
                        break;
                    }
                case 4:
                    {
                        int i = PlayerPrefs.GetInt("Pumpking");
                        PlayerPrefs.SetInt("Pumpking", i + 3);
                        break;
                    }
                case 5:
                    {
                        int i = PlayerPrefs.GetInt("Eggplant");
                        PlayerPrefs.SetInt("Eggplant", i + Random.Range(3, 5));
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
