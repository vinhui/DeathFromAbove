using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class WalkToPlayer : MonoBehaviour
{
    public Transform target;
    public float targetRange = 2f;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > targetRange)
        {
            agent.Resume();
            agent.SetDestination(target.position);
        }
        else
            agent.Stop();
    }
}