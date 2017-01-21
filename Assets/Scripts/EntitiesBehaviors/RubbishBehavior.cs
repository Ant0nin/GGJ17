using UnityEngine;
using System.Collections;

public class RubbishBehavior : TemporaryEntity
{
    public static Vector2 windForce = new Vector2(0f, 0f); // TODO : ajust
    public BallBehavior ballPrefab;

    private WavesProperties wavesProps;
    private Rigidbody2D rb;

    private bool wasInWater = false;

    protected override void Start()
    {
        base.Start();
        wavesProps = WavesProperties.getInstance();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 waterForce = wavesProps.evalForceToApply(transform.position);
        rb.AddForce(waterForce);
        rb.AddForce(windForce);

        bool isInWater = wavesProps.isPointInWater(transform.position);
        if(isInWater && !wasInWater) // entering into the water...
        {
            GameObject.Instantiate<BallBehavior>(ballPrefab, transform.position, transform.rotation);
            wasInWater = true;
        }

    }

    private IEnumerator KillMe()
    {
        yield return new WaitForSeconds(timeToLive);
        DestroyImmediate(this.gameObject);
    }
}
