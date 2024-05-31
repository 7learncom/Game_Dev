using UnityEngine;
using UnityEngine.UI;

public class GC : MonoBehaviour
{
    [SerializeField] private CarPhysics car;
    [SerializeField] private RectTransform speedUI;

    private void Update()
    {
        speedUI.localEulerAngles = Vector3.forward * (98.76f + -(car.GetSpeed() / 1.3f));
    }
}
