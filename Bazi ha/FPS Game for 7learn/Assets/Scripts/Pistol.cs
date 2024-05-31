using UnityEngine;

public class Pistol : GunBase, IGun
{

    private void Start()
    {
        GetNeeds();
    }

    void Update()
    {
        RotateTowardAim();
    }

    public void Fire(RaycastHit _hit)
    {
        if (!FireCheck())
            return;

        if (_hit.collider.CompareTag("DC"))
            _hit.collider.transform.root.GetComponent<Health>().DealDamage(damage, _hit.point);

        if (_hit.collider.gameObject.GetComponent<Health>() != null)
        {
            _hit.collider.gameObject.GetComponent<Health>().DealDamage(damage, _hit.point);
        }
        bullet--;
        anim.CrossFade(recoil, 0.1f);
        bulletShell_FX.Play();
        soundPlayer.PlayOneShot(shotSound);
        shootedTime = Time.time + fireRate;
    }

    public void Reload()
    {
        ReloadGun();
    }
}
