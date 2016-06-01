using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunData gunData;
    public Transform weaponEnd;

    private float timer;

    private bool canShoot;

    private void Update()
    {
        if (!canShoot)
        {
            if (timer <= 0)
                canShoot = true;
            else
                timer -= Time.deltaTime;
        }
    }

    public void TryShoot()
    {
        if (canShoot)
        {
            GameObject proj = (GameObject)Instantiate(gunData.projectile.prefab, weaponEnd.position, weaponEnd.rotation);
            proj.AddComponent<Projectile>().projectile = gunData.projectile;

            canShoot = false;
            timer = gunData.rateOfFire;
        }
    }
}