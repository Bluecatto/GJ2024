
using Unity.VisualScripting;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light globalLight;
    private float intensity;
    private float timeUntilSwitch;
    public float MonsterScaling;
    public bool isDay;

    [Header("Daytime Cycle Settings")]
    [SerializeField] private float dayTimeDuration;
    [SerializeField] private float nightTimeDuration;

    // Start is called before the first frame update
    void Start()
    {
        intensity = globalLight.intensity;
        timeUntilSwitch = dayTimeDuration;
        isDay = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //this.transform.eulerAngles += new Vector3(cycleSpeed * Time.deltaTime, 0f, 0f);  //WERKT NIET

        timeUntilSwitch -= Time.deltaTime;

        if (timeUntilSwitch <= 0)
        {
            if (isDay)
            {
                isDay = false;
                timeUntilSwitch = nightTimeDuration;
            }
            else
            {
                isDay = true;
                timeUntilSwitch = dayTimeDuration;
            }
        }
        if (isDay)
        {
            if (globalLight.intensity < intensity)
            {
                globalLight.intensity += Time.deltaTime * 0.25f;
            }
        }
        else if (globalLight.intensity > 0)
        {
            globalLight.intensity -= Time.deltaTime * 0.25f;
        }
    }
}
