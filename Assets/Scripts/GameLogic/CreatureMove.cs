using UnityEngine;
using System.Collections;

public class CreatureMove : MonoBehaviour
{
    public float offset = 0f;
    public float distance = 1f;
    public float speed = 1f;

    private float originalPosX;
    private SpriteRenderer sprite;
    private Vector3 originScale;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalPosX = transform.position.x;
        originScale = transform.localScale;
    }

    void Update()
    {
        float old_X = transform.position.x;

        float X = originalPosX + Mathf.Cos((Time.time + offset) * speed) * distance;
        transform.position = new Vector3(
            X,
            transform.position.y,
            transform.position.z
        );

        if (old_X > X) { // go to left...
            transform.localScale = new Vector3(originScale.x, originScale.y, originScale.z);
        }
        else { // go to right...
            transform.localScale = new Vector3(-originScale.x, originScale.y, originScale.z);
        }
    }
}
