using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public PlayerData knight;
	public PlayerData elf;
	public PlayerData wizard;

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