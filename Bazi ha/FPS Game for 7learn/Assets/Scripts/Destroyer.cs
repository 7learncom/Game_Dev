using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
