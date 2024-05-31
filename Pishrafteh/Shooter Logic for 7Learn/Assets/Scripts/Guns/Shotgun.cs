using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun, IShot
{
    public void Shot()
    {
        for (int i = 0; i < bulletSpread; i++)
        {
            Debug.Log("shotgun dealed " + damage + " damage");
        }
    }
}
