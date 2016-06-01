using UnityEngine;

public class AIGunController : MonoBehaviour
{
    public Gun gun;
    public float maxRotateAngle = 80f;
    public float minShootAngleDifference = 5f;
    public float targetShootingRange = 9f;
    public float rotateSpeed = .5f;

    public void Do(Transform target)
    {
        RotateTowards(target.position);

        if (Vector3.Distance(transform.position, target.position) < targetShootingRange && gun != null)
        {
            if (Vector3.Angle(target.position - gun.transform.position, gun.transform.forward) < minShootAngleDifference)
            {
                gun.TryShoot();
            }
        }
    }

    public void RotateTowards(Vector3 point)
    {
        Vector3 dir = (point - gun.transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        var a = Quaternion.Slerp(gun.transform.rotation, lookRot, Time.deltaTime * rotateSpeed);

        if (Quaternion.Angle(transform.rotation, a) < maxRotateAngle)
            gun.transform.rotation = a;
    }
}