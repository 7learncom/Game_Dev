using UnityEngine;

public class Aim : MonoBehaviour
{
    public RaycastHit hit;
    [SerializeField] private GameObject debugger;

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 9999f, Color.red);
        Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * 9999f, out hit);
        try
        {
            debugger = hit.collider.gameObject;
        }
        catch (System.Exception) { }
    }
}
