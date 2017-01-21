using UnityEngine;
using System.Collections;

public class RubbishController : MonoBehaviour
{
    public float timeToLive = 5f;

    private IEnumerator coroutineKillMe;
    
    void Start()
    {
        coroutineKillMe = KillMe();
        StartCoroutine(coroutineKillMe);
    }

    private IEnumerator KillMe()
    {
        yield return new WaitForSeconds(timeToLive);
        DestroyImmediate(this.gameObject);
    }
}
