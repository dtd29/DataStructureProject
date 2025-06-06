using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    private GameObject spawner;
    private bool isMouseClick;
    private Vector3 mousePosition;

    void Awake()
    {
        spawner = transform.GetChild(0).gameObject;
    }
    void Start()
    {
        isMouseClick = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isMouseClick && !GameManager.Instance.isTalking)
            {
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isMouseClick = true;
                Instantiate(bullet, spawner.transform.position, Quaternion.AngleAxis(RotateGunTowardsMouse()-90, Vector3.forward));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isMouseClick)
            {
                isMouseClick = false;
            }
        }
    }

    float RotateGunTowardsMouse()
    {
        Vector2 direction = (mousePosition - transform.position).normalized;

        float calculatedAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return calculatedAngle;
    }

}
