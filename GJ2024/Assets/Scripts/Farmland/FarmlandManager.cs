using UnityEngine;

public class FarmlandManager : MonoBehaviour
{
    [SerializeField] private GameObject farmlandGhostPrefab;
    [SerializeField] private GameObject barnGhostPrefab;
    private Camera cam;
    public bool placing;
    [SerializeField] public LayerMask validFloor;
    [SerializeField] public LayerMask invalidFloor;
    [SerializeField] public GameObject[] crops;

    public AudioSource hoeLand;

    private Rigidbody player;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        player = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKey(KeyCode.R))
        {
            SpawnThing();
        }*/
/*        if (Input.GetKey(KeyCode.T))
        {
            SpawnThing(barnGhostPrefab);
        }*/

/*        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Farmland(Clone)")
                {
                    FarmlandScript farmland = hit.collider.GetComponent<FarmlandScript>();
                    if (farmland.attachedCrop == null)
                    {
                        Instantiate(crops[Random.Range(0, crops.Length)], hit.transform);
                        farmland.attachedCrop = farmland.gameObject.transform.GetChild(0).gameObject;
                    }
                    else
                    {
                        Crops crop = farmland.attachedCrop.GetComponent<Crops>();
                        crop.Harvest();
                        farmland.hasPlant = true;
                        Instantiate(crops[Random.Range(0, crops.Length)], hit.transform);
                    }
                }
            }
        }*/
    }
    public void SpawnThing()
    {
        if (!placing)
        {
            RaycastHit hit;
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, validFloor))
            {
                if (hit.rigidbody != null)
                {
                    hit.point = new Vector3(hit.point.x, -1.2f, hit.point.z);
                    Instantiate(farmlandGhostPrefab, hit.point, Quaternion.identity);
                    hoeLand.Play();
                    placing = true;
                }
            }
        }
    }
}
