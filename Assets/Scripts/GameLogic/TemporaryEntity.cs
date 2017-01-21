using UnityEngine;
using System.Collections;

public class TemporaryEntity : MonoBehaviour
{
    public float timeToLive = 5f;
    
    protected virtual void Start()
    {
        IEnumerator coroutineKillMe = KillMe();
        StartCoroutine(coroutineKillMe);
    }
    
    private IEnumerator KillMe()
    {
        yield return new WaitForSeconds(timeToLive);
        DestroyImmediate(this.gameObject);
    }
}
