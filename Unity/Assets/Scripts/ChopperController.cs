using UnityEngine;

[RequireComponent(typeof(ChopperMotor))]
public class ChopperController : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform projector;

    private ChopperMotor motor;
    private new Camera camera;

    public ChopperGun leftGun;
    public ChopperGun rightGun;

    private void Awake()
    {
        motor = GetComponent<ChopperMotor>();
        camera = Camera.main;
    }

    private void Update()
    {
        motor.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        RaycastHit hit = new RaycastHit();
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 200f, groundLayer))
        {
            projector.position = hit.point + Vector3.up * 4;
            if (hit.point.x < motor.position.x)
            {
                leftGun.enabled = true;
                rightGun.enabled = false;
                leftGun.RotateTowards(hit.point);
            }
            else if (hit.point.x > motor.position.x)
            {
                leftGun.enabled = false;
                rightGun.enabled = true;
                rightGun.RotateTowards(hit.point);
            }
        }
    }
}