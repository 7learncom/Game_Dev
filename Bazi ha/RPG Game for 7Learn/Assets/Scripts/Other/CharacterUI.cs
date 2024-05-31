using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    private Health health;

    private void Start()
    {
        health = transform.root.gameObject.GetComponent<Health>();
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
        healthBar.fillAmount = (1 / health.MaxHealth) * health.HealthPoint;
    }
}
