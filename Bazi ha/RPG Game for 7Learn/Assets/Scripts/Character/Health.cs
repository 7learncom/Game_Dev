using UnityEngine;

public class Health : MonoBehaviour, IDealDamage
{
    [SerializeField] private float health = 100;
    public float HealthPoint { private set { health = value; } get { return health; } }

    [SerializeField] private float maxHealth = 100;
    public float MaxHealth { private set { maxHealth = value; } get { return maxHealth; } }
    [SerializeField] private float hpRegen = 0.4f;

    [SerializeField] private CharacterAnimation animan;

    private void Update()
    {
        HPPerSecond();

        if (health <= 0)
            Die();
    }

    private void HPPerSecond()
    {
        if (health >= maxHealth)
            return;

        health += hpRegen * Time.deltaTime;
    }

    public void DealDamage(float _damage)
    {
        health -= _damage;
    }

    public void Die()
    {
        if (animan)
            animan.isDead = true;

        Debug.Log(gameObject.name + " are dead!");
    }
}
