using UnityEngine;

[RequireComponent(typeof(ChopperMotor))]
public class ChopperController : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform projector;

    private ChopperMotor motor;
    private new Camera camera;

    public ChopperGunController leftGun;
    public ChopperGunController rightGun;

    public Animator animator;

    private void Awake()
    {
        motor = GetComponent<ChopperMotor>();
        camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (CheckBounds() > 0)
            HandleKeyboard();
        HandleMouse();
        Animator();
    }

    private void Animator()
    {
        if (animator != null)
        {
            animator.SetFloat("SideSpeed", motor.rigidbody.velocity.x);
            animator.SetFloat("ForwardSpeed", motor.rigidbody.velocity.z);
        }
    }

    private void HandleKeyboard()
    {
        motor.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void HandleMouse()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 200f, groundLayer))
        {
            projector.gameObject.SetActive(true);
            projector.position = new Vector3(hit.point.x, projector.position.y, hit.point.z);
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
        else
        {
            projector.gameObject.SetActive(false);
        }
    }

    private float CheckBounds()
    {
        Vector3 screenPoint = camera.WorldToScreenPoint(motor.position);
        float dist = Mathf.Min(screenPoint.x, screenPoint.y, camera.pixelWidth - screenPoint.x, camera.pixelHeight - screenPoint.y);

        if (dist < 0)
        {
            Vector3 norm = Vector3.zero;

            if (screenPoint.x < 0)
                norm += Vector3.right;
            if (screenPoint.x > camera.pixelWidth)
                norm += Vector3.left;
            if (screenPoint.y < 0)
                norm += Vector3.forward;
            if (screenPoint.y > camera.pixelHeight)
                norm += Vector3.back;

            Vector3 worldPoint = camera.ScreenToWorldPoint(Clamp(screenPoint, Vector3.one, new Vector3(camera.pixelWidth - 1, camera.pixelHeight - 1, 100)));
            motor.Set(new Vector3(worldPoint.x, motor.position.y, worldPoint.z), motor.rotation);
            motor.Bounce(norm.normalized);
        }

        return dist;
    }

    private Vector3 Clamp(Vector3 a, Vector3 min, Vector3 max)
    {
        return new Vector3(Mathf.Clamp(a.x, min.x, max.x), Mathf.Clamp(a.y, min.y, max.y), Mathf.Clamp(a.z, min.z, max.z));
    }
}