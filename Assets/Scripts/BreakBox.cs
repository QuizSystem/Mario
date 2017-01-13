using UnityEngine;
using System.Collections;
//using PathologicalGames;
public class BreakBox : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite hitSprite;
    public GameObject breakBox;
    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(12, 19);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        //if ((c.collider.bounds.max.y < transform.position.y) && (Mathf.Abs(transform.position.x - c.transform.position.x) <=.7f) && c.collider.tag == "Player")
        // The position check may need to be better.
        if ((c.collider.bounds.max.y < transform.position.y) && (Mathf.Abs(transform.position.x - c.transform.position.x) <= .7f) && c.collider.tag == "Player")
        {
            Instantiate(breakBox.transform, transform.position, Quaternion.identity);
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }

    }

    void DelaySpawn()
    {


    }
}



