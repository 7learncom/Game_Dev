using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject sword;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gun.GetComponent<IShot>().Shot();
        }
    }
}