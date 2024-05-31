using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    [SerializeField] private CharacterAnimation animan;
    private bool isDead;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target)
            agent.SetDestination(target.position);

        if (target)
            animan.run = (Vector3.Distance(transform.position, target.position) > agent.stoppingDistance) ? true : false;
        else
            animan.run = false;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;

        if (_target.CompareTag("Enemy") && GetComponent<MeleeAttack>())
            GetComponent<MeleeAttack>().SetTarget(_target);
            
    }
}
