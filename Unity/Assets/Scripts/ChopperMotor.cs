using UnityEngine;

public class ChopperMotor : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotateSpeed = 7.5f;

    public void Move(float horizontal, float vertical)
    {
        Vector3 forward = Vector3.up * vertical * moveSpeed * Time.deltaTime;
        Vector3 right = Vector3.right * horizontal * moveSpeed * Time.deltaTime;

        transform.position += forward + right;
    }

    public void RotateTowards(Vector3 point)
    {
        Vector3 vectorToTarget = point - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
    }
}