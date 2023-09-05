using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject[] levels1;
	public GameObject[] levels2;
	public GameObject[] levels3;
	public GameObject[] levels4;
	public GameObject[] levels5;
	public GameObject[] shop;
	public GameObject[] boss;

	public bool isLevelCompleted = false;

	private RandomHolleSpawn rhs;

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

		if (Input.GetKeyDown(KeyCode.Slash))
		{
			isLevelCompleted = true;
		}
		else
		{
			isLevelCompleted = false;
		}

		if (isLevelCompleted)
		{
			rhs = FindAnyObjectByType<RandomHolleSpawn>().GetComponent<RandomHolleSpawn>();
			rhs.CreateHolle();
		}
	}

	public void RestartLevel()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}
}