using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public AIMovement movement;
    public AIGunController gunController;

    private bool activated = false;
    public float aggroRange = 30f;

    private void Awake()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!target.gameObject.activeInHierarchy)
            return;

        if (!activated && Vector3.Distance(transform.position, target.position) < aggroRange)
            activated = true;

        if (activated)
        {
            if (movement != null && movement.enabled)
                movement.Do(target);
            if (gunController != null && gunController.enabled)
                gunController.Do(target);
        }
    }
}