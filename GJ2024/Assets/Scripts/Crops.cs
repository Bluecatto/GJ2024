using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
    [Header("1. carrot 2.corn 3.tomato")]
    public int vegetable = 1;

    public int plantLevel = 0;
    public int maxlevel = 5;

    public bool canRegrow = true;
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
        if (!isupgrading && plantLevel <= maxlevel - 1)
        {
            isupgrading = true;
            Invoke("UpgradeCrop", delay[plantLevel] + Random.Range(0.1f, 5f));
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
            // add to inventory

            switch (vegetable)
            {
                case 1:
                    {
                        int i = PlayerPrefs.GetInt("Carrots");
                        PlayerPrefs.SetInt("Carrots", i + Random.Range(1, 4));
                        break;
                    }
                case 2:
                    {
                        //add corn
                        break;
                    }
                case 3:
                    {
                        //add tomato
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
