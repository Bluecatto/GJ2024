using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public static bool isDay;
    [SerializeField] private float cycleSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.eulerAngles += new Vector3(cycleSpeed * Time.deltaTime, 0f, 0f);
    }
}
