using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun, IShot
{

    public void Shot()
    {
        Debug.Log("pistol dealed " + damage + " damage");
        Reload();
    }

}
