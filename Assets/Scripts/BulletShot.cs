using UnityEngine;
using System.Collections;
//using PathologicalGames;
public class BulletShot : MonoBehaviour
{
    public GameObject explosion;		// Prefab of explosion effect.
    // Use this for initialization
    // Update is called once per frame
    void Start()
    {
        gameObject.layer = 13;
    }
    void Update()
    {
        StartCoroutine(DelayDestroy(2f));
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        //    OnExplode();
        if (coll.tag.Equals("Bound") || coll.tag.Equals("Bullet") || coll.tag.Equals("Item")) return;
        StartCoroutine(DelayDestroy(0));
       // PoolManager.Pools[Utils.nameParticles].Spawn(explosion.transform, transform.position, Quaternion.identity);
    }
    IEnumerator DelayDestroy(float time )
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
         //   PoolManager.Pools[Utils.nameBullet].Despawn(gameObject.transform);
           
        }
       
    }
}
