using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun, IShot
{

    public void Shot()
    {
        Debug.Log("Rifle dealed " + damage + " damage");
    }
}
