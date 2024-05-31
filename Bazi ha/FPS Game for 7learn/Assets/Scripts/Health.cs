using UnityEngine;

public enum TargetHealth { Zombie, Player }

public class Health : MonoBehaviour
{
    [SerializeField] private TargetHealth targetHealth = TargetHealth.Zombie;
    [SerializeField] private float health = 80;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private GameObject bloodPrefab;
    private bool isDead;

    public void DealDamage(float _damage, Vector3 hitPos)
    {
        if (isDead)
            return;

        health -= _damage;
        if (targetHealth == TargetHealth.Zombie)
        {
            var a = Instantiate(bloodPrefab, hitPos, Quaternion.identity);
            Destroy(a, 5);
        }

        if (health <= 0)
            Die();
    }

    private void Die()
    {
        switch (targetHealth)
        {
            case TargetHealth.Zombie:
                GetComponent<Zombie_AI>().Die();
                break;
            case TargetHealth.Player:
                Time.timeScale = 0;
                break;
        }

        isDead = true;
    }
}
