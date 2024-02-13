using UnityEngine;

public class FarmlandManager : MonoBehaviour
{
    [SerializeField] private GameObject farmlandGhostPrefab;
    private Camera cam;
    public bool placing;
    [SerializeField] public LayerMask validFloor;
    [SerializeField] public LayerMask invalidFloor;
    [SerializeField] public GameObject[] crops;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && !placing)
        {
            placing = true;
            //Instantiate(farmland);

            RaycastHit hit;
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, validFloor))
            {
                if (hit.rigidbody != null)
                {
                    hit.point = new Vector3(hit.point.x, -1.2f, hit.point.z);
                    Instantiate(farmlandGhostPrefab, hit.point, Quaternion.identity);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name == "Farmland(Clone)")
                {
                    FarmlandScript farmland = hit.collider.GetComponent<FarmlandScript>();
                    if (!farmland.hasPlant)
                    {
                        farmland.hasPlant = true;
                        Instantiate(crops[Random.Range(0, crops.Length)], hit.transform);
                    }
                }
            }
        }
    }
}
