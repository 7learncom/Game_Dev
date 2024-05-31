using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject weapons;
    [SerializeField] private Transform gunsParent;
    private Aim aim;

    private void Start()
    {
        aim = Camera.main.GetComponent<Aim>();
    }

    void Update()
    {
        GunTransformFixer();

        if (Input.GetKey(KeyCode.Mouse0))
            Fire();

        if (Input.GetKeyDown(KeyCode.R))
            weapons.GetComponent<IGun>().Reload();
    }

    private void Fire()
    {
        weapons.GetComponent<IGun>().Fire(aim.hit);
    }

    private void GunTransformFixer()
    {
        gunsParent.localEulerAngles = new Vector3(
            Mathf.LerpAngle(gunsParent.localEulerAngles.x, Camera.main.transform.localEulerAngles.x, 5 * Time.deltaTime),
            0f,
            0f);

        Vector3 targetGunPos = (Input.GetKey(KeyCode.Mouse1)) ? weapons.GetComponent<GunBase>().aimPos : weapons.GetComponent<GunBase>().normalPos;
        weapons.transform.localPosition = Vector3.Lerp(weapons.transform.localPosition, targetGunPos, 5 * Time.deltaTime);
        var fov = (Input.GetKey(KeyCode.Mouse1)) ? 33f : 53.1f;
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, fov, 5 * Time.deltaTime);
    }
}
