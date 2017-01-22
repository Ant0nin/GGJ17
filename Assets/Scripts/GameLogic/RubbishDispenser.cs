using UnityEngine;

public class RubbishDispenser : MonoBehaviour
{
    public float tempo = 5f;
    public Vector2 initialForce = new Vector2(0f, 0f); // TODO : ajust
    public RubbishBehavior[] rubbishPrefabs;

    void Start()
    {
        InvokeRepeating("SpawnRubbish", 0f, tempo);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Walls_Filter"), LayerMask.NameToLayer("Rubbish"), true);
    }

    private void SpawnRubbish()
    {
        int index = Random.Range(0, rubbishPrefabs.Length);
        RubbishBehavior targetPrefab = rubbishPrefabs[index];

        RubbishBehavior rub = GameObject.Instantiate<RubbishBehavior>(targetPrefab, transform.position, transform.rotation);
        rub.GetComponent<Rigidbody2D>().AddForce(initialForce);
    }
}
