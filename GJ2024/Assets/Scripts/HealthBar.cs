using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject GameOverText;
    public Image health;
    public float Health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Health regen
        if (Health < 100f)
        {
            UpdateHealthBar(Time.deltaTime);
        }
    }

    public void UpdateHealthBar(float amountToAdd)
    {
        Health += amountToAdd;

        if(Health <= 0)
        {
            GameOverText.SetActive(true);
        }

        health.fillAmount = Health / 100f;
    }
}
