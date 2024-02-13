using UnityEngine;
public class FarmlandGhostScript : MonoBehaviour
{
    private FarmlandManager manager;
    [SerializeField] GameObject farmland;
    private bool hasCrop = false;
    private Camera cam;
    private Vector3 mousePos;
    private bool isValid;
    private Renderer render;
    [SerializeField] private float damping;

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
            //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            //mousePos.y = 0f;
            //transform.position = Vector3.Lerp(transform.position, hit.point, 10 * Time.deltaTime);

            RaycastHit hit;
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, manager.validFloor))
            {
                if (hit.rigidbody != null)
                {
                    hit.point = new Vector3(hit.point.x, -1.2f, hit.point.z);
                    transform.position = Vector3.Lerp(transform.position, hit.point, damping * Time.deltaTime);
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
            RaycastHit[] hit = Physics.BoxCastAll(transform.position, new Vector3(1.1f, 0f, 1.1f), Vector3.down, Quaternion.identity, 0.25f, manager.invalidFloor);
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
            Instantiate(farmland, transform.position, Quaternion.identity);
            manager.placing = false;
            Destroy(gameObject);
        }
    }
}
