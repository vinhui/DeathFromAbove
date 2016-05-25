using UnityEngine;

public class ChopperGun : MonoBehaviour
{
    public ProjectileData projectile;
    public float rotateSpeed;
    public float rateOfFire = .5f;
    public Transform weaponEnd;

    private float timer;

    private void Update()
    {
        if (timer <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject proj = (GameObject)Instantiate(projectile.prefab, weaponEnd.position, weaponEnd.rotation);
                proj.AddComponent<Projectile>().projectile = projectile;

                timer = rateOfFire;
            }
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void RotateTowards(Vector3 point)
    {
        Vector3 dir = (point - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * rotateSpeed);
    }
}