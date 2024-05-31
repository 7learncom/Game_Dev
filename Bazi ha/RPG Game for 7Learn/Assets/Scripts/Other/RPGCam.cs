using UnityEngine;

public class RPGCam : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveThreshold = 10;
    [SerializeField] private Transform destination;
    [SerializeField] private GameObject player;
    private int switcherX;
    private int switcherZ;

    private void Update()
    {
        switcherX = GetSwitcher(Input.mousePosition.x, Screen.width);
        switcherZ = GetSwitcher(Input.mousePosition.y, Screen.height);

        transform.position = new Vector3(transform.position.x + (moveSpeed * switcherX * Time.deltaTime), transform.position.y, transform.position.z + (moveSpeed * switcherZ * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.CompareTag("Enemy"))
                {
                    player.GetComponent<CharacterMovement>().SetTarget(hit.collider.transform);
                }
                else
                {
                    destination.position = hit.point;
                    player.GetComponent<CharacterMovement>().SetTarget(destination);
                }
            }
        }
    }

    public int GetSwitcher(float mouseX, int screenSize)
    {
        if (mouseX <= moveThreshold)
            return -1;
        else if (mouseX >= (screenSize - moveThreshold))
            return 1;
        else
            return 0;
    }
}
