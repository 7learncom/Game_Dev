using UnityEngine;
using UnityEngine.AI;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float damage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackSpeed;

    private float attackedTime;
    [SerializeField] private CharacterAnimation animan;

    private void Start()
    {
        GetComponent<NavMeshAgent>().stoppingDistance = attackRange - 0.1f;
    }

    private void Update()
    {
        if (target == null)
            return;

        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            Damage();
            animan.attack = true;
        }
        else
            animan.attack = false;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void Damage()
    {
        if (target.gameObject.GetComponent<IDealDamage>() == null)
            return;

        if (Time.time >= attackedTime + attackSpeed)
        {
            target.gameObject.GetComponent<IDealDamage>().DealDamage(damage);
            attackedTime = Time.time;
        }
    }
}
