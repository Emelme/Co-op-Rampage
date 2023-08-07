using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			RestartLevel();
		}
	}

	public void RestartLevel()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}
}