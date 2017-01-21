using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GullBehavior : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

	void Update()
    {
        float offsetX = 0f;//Mathf.Cos(Time.time);

        transform.position = new Vector3(
            transform.position.x + offsetX,
            transform.position.y,
            transform.position.z
        );
	}
    
    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject go = other.gameObject;

        if (go.tag == "Rubbish")
        {
            bool isDead = anim.GetBool("isDead");
            if(!isDead)
            {
                anim.SetBool("isDead", true);

                Vector2 collisionPoint = other.contacts[0].point;
                Vector2 gullPosition = new Vector2(this.transform.position.x, this.transform.position.y);

                Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
                Vector2 dir = -Vector3.Normalize(collisionPoint - gullPosition);
                rb.AddForce(new Vector2(dir.x, dir.y) * 500f);
            }


        }
    }
}
