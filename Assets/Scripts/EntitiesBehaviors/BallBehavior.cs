using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    public float timeToLive = 5f;

    private WavesProperties wavesProps;
    private IEnumerator coroutineKillMe;

    void Start () {
        wavesProps = WavesProperties.getInstance();

        coroutineKillMe = KillMe();
        StartCoroutine(coroutineKillMe);
    }

    void Update()
    {
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        bool isInWater = wavesProps.isPointInWater(pos);
        if (!isInWater)
            DestroyImmediate(this.gameObject);
    }

    private IEnumerator KillMe()
    {
        yield return new WaitForSeconds(timeToLive);
        DestroyImmediate(this.gameObject);
    }
}
