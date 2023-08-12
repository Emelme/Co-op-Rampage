using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public enum CharachterType
	{
		knight,
		elf,
		wizard
	}

	public CharachterType charachterType;

	public PlayerData[] playerDatas = new PlayerData[3];

	private void Awake()
	{
		charachterType = (CharachterType)Random.Range(0, 3);
	}

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