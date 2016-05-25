using UnityEngine;
using System.Collections;

public class WalkCircles : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float rotateSpeed = 100f;

    public void Update()
    {
        transform.position += transform.forward * forwardSpeed * Time.deltaTime;
        transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
    }
}
