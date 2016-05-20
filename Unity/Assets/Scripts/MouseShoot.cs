using UnityEngine;
using System.Collections;

public class MouseShoot : MonoBehaviour
{
    public float rateOfFire = .5f;
    public int damage = 10;
    public LayerMask hitLayers;

    public Transform weaponEnd;
    public LineRenderer lineRenderer;

    private float timer;

    private void Awake()
    {
        lineRenderer.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (timer <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                lineRenderer.gameObject.SetActive(true);
                lineRenderer.SetPosition(0, weaponEnd.position);

                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 100, hitLayers);
                if (hit)
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                    Health h = hit.transform.GetComponent<Health>();
                    if (h != null)
                    {
                        h.health -= damage;
                    }
                    lineRenderer.SetPosition(1, hit.point);
                }
                else
                    lineRenderer.SetPosition(1, transform.right * 100);

                timer = rateOfFire;
            }
        }
        else
        {
            timer -= Time.deltaTime;
            lineRenderer.gameObject.SetActive(false);
        }
    }
}
