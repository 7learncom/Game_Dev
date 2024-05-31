using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Gun, IShot
{
    public void Shot()
    {
        Debug.Log("Sniper dealed " + damage + " damage");
    }
}
