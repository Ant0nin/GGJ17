using UnityEngine;
using System.Collections;

public class RubbishBehavior : MonoBehaviour
{
    public static Vector2 windForce = new Vector2(0f, 0f); // TODO : ajust
    public float timeToLive = 5f;

    private WavesProperties wavesProps;
    private IEnumerator coroutineKillMe;
    private Rigidbody2D rb;
    
    void Start()
    {
        wavesProps = WavesProperties.getInstance();
        rb = GetComponent<Rigidbody2D>();
        coroutineKillMe = KillMe();
        StartCoroutine(coroutineKillMe);
    }

    void Update()
    {
        Vector2 waterForce = wavesProps.evalForceToApply(transform.position);
        rb.AddForce(waterForce);
        rb.AddForce(windForce);
    }

    private IEnumerator KillMe()
    {
        yield return new WaitForSeconds(timeToLive);
        DestroyImmediate(this.gameObject);
    }
}
