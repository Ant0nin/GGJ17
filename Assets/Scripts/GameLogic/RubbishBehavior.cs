using UnityEngine;
using System.Collections;

public class RubbishBehavior : TemporaryEntity
{
    public BallBehavior ballPrefab;

    private Rigidbody2D rb;
    private bool wasInWater = false;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool isInWater = WavesCalculator.isPointInWater(transform.position);
        if(isInWater &&  !wasInWater) // entering into the water...
            SpawnBall();

        Vector2 waterForceToOutdoor = WavesCalculator.evalForceToOutdoor(transform.position);
        Vector2 waterHorizontalForce = WavesCalculator.evalHorizontalForce(transform.position);

        rb.AddForce(waterForceToOutdoor);
        if (rb.velocity.x < waterHorizontalForce.x)
            rb.AddForce(waterHorizontalForce);
    }

    void ApplyWaterForce()
    {
       
    }

    private void SpawnBall()
    {
        Vector3 spawnPosition = new Vector3(
            transform.position.x,
            transform.position.y - 5f, // TODO : ajust
            transform.position.z
        );

        GameObject.Instantiate<BallBehavior>(ballPrefab, spawnPosition, transform.rotation);

        wasInWater = true;
    }
}
