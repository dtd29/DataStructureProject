using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 500f;
    private float h;
    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!GameManager.Instance.isTalking)
        {
            h = Input.GetAxisRaw("Horizontal");
            rb.linearVelocityX = h * speed;

            if (h != 0)
            {
                anim.SetBool("isWalking", true);
                if (h > 0)
                {
                    gameObject.transform.localScale = new Vector3(100, 100, 100);
                }
                else if (h < 0)
                {
                    gameObject.transform.localScale = new Vector3(-100, 100, 100);
                }
            }
            else
            {
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            rb.linearVelocityX = 0;
            anim.SetBool("isWalking", false);
        }
    }
}
