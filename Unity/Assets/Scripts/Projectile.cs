using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData projectile;

    private Vector3 deltaPos;

    private void Start()
    {
        Destroy(gameObject, projectile.destroyTime);
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