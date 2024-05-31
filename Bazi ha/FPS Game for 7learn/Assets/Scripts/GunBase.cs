using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public Vector3 normalPos;
    public Vector3 aimPos;

    [Header("Shooting")]
    [SerializeField] protected float damage;
    [SerializeField] protected int bullet;
    [SerializeField] protected int bulletBag;
    [SerializeField] protected int maxClipBullets;
    [SerializeField] protected float fireRate;
    protected float shootedTime;
    [SerializeField] protected float reloadingTime;
    [SerializeField] protected AudioClip shotSound;
    [SerializeField] protected ParticleSystem bulletShell_FX;

    [Header("Animations")]
    protected int recoil;
    protected Animator anim;

    private GameObject mainCamera;
    private Aim aim;
    protected AudioSource soundPlayer;

    protected void GetNeeds()
    {
        mainCamera = Camera.main.gameObject;
        aim = mainCamera.GetComponent<Aim>();
        soundPlayer = GetComponent<AudioSource>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        recoil = Animator.StringToHash("Recoil");
    }

    protected void RotateTowardAim()
    {
        try
        {
            transform.LookAt(aim.hit.point);
        }
        catch (System.Exception){}
    }

    protected bool FireCheck()
    {
        if (bullet <= 0 && bulletBag <= 0)
            return false;

        if (Time.time < shootedTime + fireRate)
            return false;

        if (bullet <= 0)
        {
            ReloadGun();
            return false;
        }

        return true;
    }

    protected void ReloadGun()
    {
        int bulletNeeds = maxClipBullets - bullet;

        if (bulletBag >= bulletNeeds)
        {
            bullet += bulletNeeds;
            bulletBag -= bulletNeeds;
        }
        else
        {
            bullet += bulletBag;
            bulletBag = 0;
        }

        shootedTime = Time.time + reloadingTime;
    }
}
