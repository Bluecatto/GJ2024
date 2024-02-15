
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light globalLight;
    [SerializeField] private Color[] dayNightColors;
    private float timeUntilSwitch;
    public float MonsterScaling;
    public bool isDay;

    [Header("Daytime Cycle Settings")]
    [SerializeField] private float dayTimeDuration;
    [SerializeField] private float nightTimeDuration;

    // Start is called before the first frame update
    void Start()
    {
        timeUntilSwitch = dayTimeDuration;
        isDay = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(timeUntilSwitch);
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
            globalLight.color = Color.Lerp(globalLight.color, dayNightColors[0], 0.01f);
        }
        else
        {
            globalLight.color = Color.Lerp(globalLight.color, dayNightColors[1], 0.01f);
        }

    }
}
