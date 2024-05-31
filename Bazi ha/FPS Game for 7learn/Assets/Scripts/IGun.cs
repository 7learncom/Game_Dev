using UnityEngine;

internal interface IGun
{
    public void Fire(RaycastHit _hit);
    public void Reload();
}
