using UnityEngine;
public class BlueprintScript : MonoBehaviour
{
    private FarmlandManager manager;
    private bool hasCrop = false;
    private Camera cam;
    private bool isValid;
    private Renderer render;

    [SerializeField] GameObject buildingType;
    [SerializeField] private float damping;
    [SerializeField] private float gridSize;
    [SerializeField] private float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("FarmlandManager").GetComponent<FarmlandManager>();
        render = GetComponent<Renderer>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasCrop)
        {
            if (Input.GetMouseButtonDown(1))
            {
                manager.placing = false;
                Destroy(gameObject);
            }

            //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            //mousePos.y = 0f;
            //transform.position = Vector3.Lerp(transform.position, hit.point, 10 * Time.deltaTime);

            RaycastHit hit;
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, manager.validFloor))
            {
                if (hit.rigidbody != null)
                {
                    hit.point = new Vector3(hit.point.x, yOffset, hit.point.z);
                    transform.position = Vector3.Lerp(transform.position, RoundVector(hit.point, 1/gridSize), damping * Time.deltaTime);
                }
            }


            //float scroll = Input.GetAxis("Mouse ScrollWheel");
            //transform.eulerAngles += new Vector3(0f, scroll * 4f);
        }
        if (Input.GetMouseButtonDown(0) && isValid)
        {
            hasCrop = true;
        }
    }
    private void FixedUpdate()
    {
        if (!hasCrop)
        {
            RaycastHit[] hit = Physics.BoxCastAll(RoundVector(transform.position, 1 / gridSize),
                                                  new Vector3(transform.localScale.x * 0.5f - 0.01f, 10f, transform.localScale.z * 0.5f - 0.01f),
                                                  Vector3.down,
                                                  Quaternion.identity,
                                                  Mathf.Infinity,
                                                  manager.invalidFloor);
            if (hit.Length != 0)
            {
                render.material.color = Color.red;
                isValid = false;
            }
            else
            {
                render.material.color = Color.green;
                isValid = true;
            }
        }
        else
        {
            Instantiate(buildingType, RoundVector(transform.position, 1 / gridSize), Quaternion.identity);
            manager.placing = false;
            Destroy(gameObject);
        }
    }

    private Vector3 RoundVector(Vector3 vector, float multiplier)
    {
        return new Vector3(Mathf.Round(multiplier * vector.x) / multiplier,
                           vector.y,
                           Mathf.Round(multiplier * vector.z) / multiplier);
    }
}
