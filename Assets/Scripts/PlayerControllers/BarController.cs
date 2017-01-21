using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour {

    public float bounceForce = 10f;
    public float limitLeftX = -5f;
    public float limitRightX = 5f;

	void Update ()
    {
        float offset = Input.GetAxis("Horizontal");
        float X = Mathf.Clamp(transform.position.x + offset, limitLeftX, limitRightX);

        transform.position = new Vector3(
            X,
            transform.position.y,
            transform.position.z
        );
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject go = other.gameObject;
        if(go.tag == "Ball")
        {
            Vector3 dir = -Vector3.Normalize(transform.position - go.transform.position);
            Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(dir.x, dir.y) * bounceForce;
        }
    }
}
