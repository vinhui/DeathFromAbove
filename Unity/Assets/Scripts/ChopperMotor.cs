using UnityEngine;

public class ChopperMotor : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 7.5f;

    private new Transform transform;
    public Quaternion rotation { get { return transform.rotation; } }
    public Vector3 position { get { return transform.position; } }
    public Vector3 deltaPosition { get; private set; }

    public new Rigidbody rigidbody;

    private void Awake()
    {
        transform = base.transform;
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(float horizontal, float vertical)
    {
        deltaPosition = position;

        float forward = vertical * moveSpeed * Time.deltaTime * 10;
        float right = horizontal * moveSpeed * Time.deltaTime * 10;

        rigidbody.AddForce(right, 0, forward);
        //transform.position += forward + right;
    }

    public void Set(Vector3 position, Quaternion rotation)
    {
        rigidbody.position = position;
        rigidbody.rotation = rotation;
    }

    public void RotateTowards(Vector3 point)
    {
        Vector3 dir = point - transform.position;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
    }

    public void Bounce(Vector3 normal)
    {
        normal.y = 0;
        rigidbody.velocity = Vector3.Reflect(rigidbody.velocity.normalized, normal) * 10;
    }
}