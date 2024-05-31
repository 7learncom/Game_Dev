using UnityEngine;
using UnityEngine.AI;

public class Zombie_AI : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackingDelay = 0.5f;

    private float attackedTime;
    private NavMeshAgent agent;
    private Transform player;
    private Animator anim;

    private float attackingDelayTimer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        agent.SetDestination(player.position);

        if (Vector3.Distance(transform.position, player.position) <= agent.stoppingDistance + 0.2f)
        {
            attackingDelayTimer += Time.deltaTime;
            if (attackingDelayTimer >= attackingDelay)
            {
                Attack();
            }
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
            attackingDelayTimer = 0;
        }
    }

    private void Attack()
    {
        if (Time.time >= attackedTime + attackSpeed)
        {
            Debug.Log("Attack");
            player.GetComponent<Health>().DealDamage(damage, Vector3.zero);
            attackedTime = Time.time;
        }
    }

    public void Die()
    {
        agent.isStopped = true;
        agent.enabled = false;
        anim.enabled = false;
        this.enabled = false;
    }
}
