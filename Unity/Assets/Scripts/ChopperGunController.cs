using UnityEngine;

public class ChopperGunController : MonoBehaviour
{
    public Gun gun;
    public float rotateSpeed;

    private void Awake()
    {
        if (gun == null)
            gun = GetComponent<Gun>();

        if (gun == null)
            Debug.LogError("Gun is not assinged!", this);
    }

    private void Update()
    {
        if (gun != null)
        {
            if (Input.GetMouseButton(0))
                gun.TryShoot();
        }
    }

    public void RotateTowards(Vector3 point)
    {
        Vector3 dir = (point - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * rotateSpeed);
    }
}