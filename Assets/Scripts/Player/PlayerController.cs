using Unity.Properties;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 10f;
    [SerializeField]
    private float jumpSpeed = 10f;
    [SerializeField]
    private float ForceBounce = 2;

    [SerializeField]
    public float GroundRycast = 1f;

    public LayerMask CapaSuelo;
    public LayerMask CapaEnemy;

    private new Rigidbody2D rigidbody;
    private new Collider2D collider;
    private Animator animator;
    private bool AttackCheck;
    private bool RollCheck;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        
    }

    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, GroundRycast, CapaSuelo);

        float movX = Run();
        SetDirectiorn(movX);
        animator.SetFloat("VelocityX", movX * runSpeed);

        bool inGroundead = hit.collider != null;
        float movY = Jump(inGroundead);
        animator.SetBool("InGroundead", hit.collider != null);
        animator.SetFloat("VelocityY", movY * jumpSpeed);
        Attack();
        animator.SetBool("AttackCheck", AttackCheck);
        Roll();
        animator.SetBool("RollCheck", RollCheck);

    }

    float Run()
    {
        float getDirectionX = Input.GetAxis("Horizontal");
        rigidbody.linearVelocity = new Vector2(getDirectionX * runSpeed, rigidbody.linearVelocityY);
        return getDirectionX;
    }

    float Jump(bool inGroundead)
    {
        if (Input.GetButton("Jump") && inGroundead)
        {
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocityX, jumpSpeed);
        }
        return rigidbody.linearVelocity.y;
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AttackCheck = true;
        }else if (Input.GetMouseButtonUp(0))
        {
            AttackCheck = false;
        }
    }

    void Roll()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            RollCheck = true;
            runSpeed = 12f;
        }
        else if (Input.GetButtonUp("Vertical"))
        {
            RollCheck = false;
            runSpeed = 10f;
        }
    }

    void SetDirectiorn(float MovementX)
    {
        if (MovementX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
        if (MovementX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * GroundRycast);

    }

}
