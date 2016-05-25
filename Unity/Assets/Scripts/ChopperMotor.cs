using UnityEngine;

public class ChopperMotor : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 7.5f;

    private new Transform transform;
    public Vector3 position { get { return transform.position; } }

    private void Awake()
    {
        transform = base.transform;
    }

    public void Move(float horizontal, float vertical)
    {
        Vector3 forward = Vector3.forward * vertical * moveSpeed * Time.deltaTime;
        Vector3 right = Vector3.right * horizontal * moveSpeed * Time.deltaTime;

        transform.position += forward + right;
    }

    public void RotateTowards(Vector3 point)
    {
        Vector3 dir = point - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
    }
}