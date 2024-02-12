using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crops : MonoBehaviour
{
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
            // add to inventory

            if (canRegrow)
            {
                plantLevel = goBackToLevel;
                mesh.material = mats[plantLevel];
            }
            else
            {
                Destroy(this.gameObject, 1f);
            }
        }
    }
}
