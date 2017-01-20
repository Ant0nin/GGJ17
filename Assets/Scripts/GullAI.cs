using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GullAI : MonoBehaviour
{
	void Update()
    {
        float offsetX = 0f;//Mathf.Cos(Time.time);

        transform.position = new Vector3(
            transform.position.x + offsetX,
            transform.position.y,
            transform.position.z
        ); ;
	}
    
    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject go = other.gameObject;
        if (go.tag == "Rubbish")
        {
            Destroy(gameObject);
        }
    }
}
