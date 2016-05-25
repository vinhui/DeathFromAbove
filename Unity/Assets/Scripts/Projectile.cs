using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData projectile;

    private Vector3 deltaPos;

    private float destroyTime = 2f;

    private void Awake()
    {
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
        deltaPos = transform.position;
        transform.position += transform.forward * projectile.speed * Time.deltaTime;

        RaycastHit hit;
        if (Physics.Linecast(deltaPos, transform.position, out hit, projectile.hitLayers))
        {
            Health h = hit.transform.GetComponent<Health>();
            if (h != null)
            {
                h.health -= projectile.damage;
            }
            Destroy(gameObject);
        }
    }
}