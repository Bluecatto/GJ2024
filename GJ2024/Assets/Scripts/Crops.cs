using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    [Header("1.carrot 2.corn 3.tomato 4.pumpking 5.eggplant")]
    public int plantnumber = 1;

    public int plantLevel = 0;
    public int maxlevel = 5;

    public bool canRegrow = true;
    public int goBackToLevel = 3;

    private int randomDelay;

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
        //temporary
        Debug.Log(Random.Range(1, 10) / 100);

        randomDelay = Random.Range(1, 10) % 100;

        if (Input.GetKeyDown(KeyCode.K))
        {
            Harvest();
        }
    }

    private void FixedUpdate()
    {
        if (!isupgrading && plantLevel <= maxlevel - 1)
        {
            isupgrading = true;
            Debug.Log(delay[plantLevel]);
            Invoke("UpgradeCrop", delay[plantLevel]);
        }
    }

    public void UpgradeCrop()
    {
        mesh.material = mats[plantLevel];
        plantLevel++;
        isupgrading = false;
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
}
