using UnityEngine;
//using PathologicalGames;
public class EnemySimple : MonoBehaviour
{
    public float speed;
    public float bouncePlayer;
    void Start()
    {
    }
    /// <summary>
    /// Nếu xử lý game nhiều đối tượng nhiều Level cần kiểm tra khi enemy tiệm cận Player mới cho di chuyển và hoạt động các animations
    /// </summary>
    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().velocity = new Vector2(-transform.localScale.x * speed, GetComponent<Rigidbody2D>().velocity.y);

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("Bound"))
        {
            Flip();
        }
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if ((c.collider.bounds.min.y > transform.position.y && c.collider.tag == "Player"))
        {
            gameObject.SetActive(false);
            c.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(c.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0);
            c.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, bouncePlayer);
        }
        else if ((c.collider.bounds.min.y < transform.position.y && c.collider.tag == "Player"))
        {
            GameManager.Instance.LevelFailUI();
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().isKinematic = false;
        }

    }
    private void Flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1f;
        transform.localScale = enemyScale;
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        /*
        if (coll.gameObject.tag == Tags.Player)
        {
            if (!dead)
                PhysicsHandle();
        }
        */
    }
}
