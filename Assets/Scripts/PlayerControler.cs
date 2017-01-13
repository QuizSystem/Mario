using UnityEngine;
using System.Collections;
//using PathologicalGames;
public class PlayerControler : MonoBehaviour
{

    public float SpeedPlayer = 0f;
    public float JumpPower = 0f;
    public Transform GroundCheck;
    private string axisName = "Horizontal";

    private bool jumped = false;
    private bool doubleJump = false;
    private static bool grounded = false;

    [HideInInspector]
    public Animator anim;
    [SerializeField]
    private LayerMask whatIsGround;
    public float ShootRate = 0f;
    private float _shootcurent;
    public float speedBullet;
    private float groundedRadius = .2f;
    public GameObject bulletPrefabs;
    private Transform transformPlayer;
    void Start()
    {
        anim = GetComponent<Animator>();
        transformPlayer = transform;
    }
    void Update()
    {
        float dir = Input.GetAxis("Horizontal");
        MovePlayer(dir);
        if (Input.GetKeyDown("space"))
            JumpPlayer();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(GroundCheck.position, groundedRadius, whatIsGround);
        anim.SetBool("Ground", grounded);

    }

    public void MovePlayer(float direct)
    {
        anim.SetFloat("Speed", Mathf.Abs(direct));
        transformPlayer.position += transformPlayer.right * direct * SpeedPlayer * Time.deltaTime;
        if (direct > 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        else if (direct < 0)
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

    }
    public void JumpPlayer()
    {
        if (grounded)
        {
            AddForcesJump();
            doubleJump = true;
        }
        else
        {
            if (!doubleJump) return;
            AddForcesJump();
            doubleJump = false;
        }
    }
    private void AddForcesJump()
    {
        anim.SetBool("Ground", false);
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower));

        }
    #region Handle Collider
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Coins"))
        {
            GameManager.sumcoins++;
            GameManager.UpdateCoinsDelegate(GameManager.sumcoins);
            coll.gameObject.SetActive(false);
        }
        if (coll.tag.Equals("Dead"))
        {
            GameManager.Instance.LevelFailUI();
        }
    }
    #endregion
}
