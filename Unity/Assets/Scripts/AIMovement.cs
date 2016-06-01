using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMovement : MonoBehaviour
{
    public float targetWalkingRange = 7.5f;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Do(Transform target)
    {
        float dist = Vector3.Distance(transform.position, target.position);

        if (dist > targetWalkingRange)
        {
            agent.Resume();
            agent.SetDestination(target.position);
        }
        else
        {
            agent.Stop();
            RotateTowards(target.position);
        }
    }

    private void RotateTowards(Vector3 point)
    {
        Vector3 dir = (new Vector3(point.x, transform.position.y, point.z) - transform.position).normalized;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), agent.angularSpeed * Time.deltaTime);
    }
}