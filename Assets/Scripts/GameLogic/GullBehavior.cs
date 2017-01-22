using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GullBehavior : MonoBehaviour
{
    public float bloodEmissionTimeout = 2f;

    private Animator anim;
    private ParticleSystem bloodEmitter;

    void Start()
    {
        anim = GetComponent<Animator>();
        bloodEmitter = GetComponent<ParticleSystem>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = other.gameObject;

        if (go.tag == "Rubbish")
        {
            bool isDead = anim.GetBool("isDead");
            if(!isDead)
            {
                anim.SetBool("isDead", true);

                /*Vector2 collisionPoint = other.contacts[0].point;
                Vector2 gullPosition = new Vector2(this.transform.position.x, this.transform.position.y);
                Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
                Vector2 dir = -Vector3.Normalize(collisionPoint - gullPosition);
                rb.AddForce(new Vector2(dir.x, dir.y) * 500f);*/

                bloodEmitter.Play();
                Destroy(GetComponent<CreatureMove>());
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(GetComponent<BoxCollider2D>());
                StartCoroutine(StopBloodEmission());
            }
        }
    }

    private IEnumerator StopBloodEmission()
    {
        yield return new WaitForSeconds(bloodEmissionTimeout);
        bloodEmitter.enableEmission = false;
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }
}
