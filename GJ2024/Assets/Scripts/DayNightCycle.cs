
using Unity.VisualScripting;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Light globalLight;
    private float intensity;
    private float timeUntilSwitch;
    public bool isDay;
    private HealthBar healthBar;

    public AudioSource nightTimeMusic, dayTimeMusic;

    [Header("Daytime Cycle Settings")]
    [SerializeField] private float dayTimeDuration;
    [SerializeField] private float nightTimeDuration;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("DevCube").GetComponent<HealthBar>();
        intensity = globalLight.intensity;
        timeUntilSwitch = dayTimeDuration;

        isDay = true;
        dayTimeMusic.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timeUntilSwitch -= Time.deltaTime;

        if (timeUntilSwitch <= 0)
        {
            if (isDay)
            {
                isDay = false;

                nightTimeMusic.Play();
                dayTimeMusic.Stop();

                timeUntilSwitch = nightTimeDuration;
            }
            else
            {
                isDay = true;

                dayTimeMusic.Play();
                nightTimeMusic.Stop();

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
