using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
	public void LoadSceneWithName(string scene)
	{
		SceneManager.LoadScene(scene);
	}
}