using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private RandomHolleSpawn rhs;

	public bool isLevelCompleted = false;

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

	private void Start()
	{
		rhs = FindAnyObjectByType<RandomHolleSpawn>().GetComponent<RandomHolleSpawn>();
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
			rhs.CreateHolle();
		}
	}

	public void RestartLevel()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}
}