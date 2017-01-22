using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour {
	
	public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
