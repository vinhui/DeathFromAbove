using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ChopperMotor))]
public class ChopperController : MonoBehaviour
{
    private ChopperMotor motor;
    private Camera cam;

    private void Awake()
    {
        motor = GetComponent<ChopperMotor>();
        cam = Camera.main;

        if (!cam.orthographic)
            Debug.LogWarning("Rotating towards the mouse will only work when using an orthograpic camera");
    }

    private void Update()
    {
        motor.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        motor.RotateTowards(mouse);
    }
}
