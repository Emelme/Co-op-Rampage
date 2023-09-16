using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject startLevel;

	public GameObject[] levels1;
	public GameObject[] levels2;
	public GameObject[] levels3;
	public GameObject[] levels4;
	public GameObject[] levels5;

	public GameObject[] shop1;
	public GameObject[] shop2;
	public GameObject[] shop3;
	public GameObject[] shop4;

	public GameObject[] boss;

	public GameObject[] enemy1;
	public GameObject[] enemy2;
	public GameObject[] enemy3;
	public GameObject[] enemy4;
	public GameObject[] enemy5;

	public GameObject currentLevel;

	public int levelIndexWasWas = -1;
	public int levelIndexWas = -1;
	public int currentLevelIndex = -1;

	public int levelNumber = 0;

	private PlayerMovement playerMovement;

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
		playerMovement = FindAnyObjectByType<PlayerMovement>();

		CreateNewLevel();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			RestartLevel();
		}
	}

	public void CreateNewLevel()
	{
		if (currentLevel != null)
			Destroy(currentLevel);

		if (levelNumber % 6 == 1)
		{
			levelIndexWasWas = -1;
			levelIndexWas = -1;
		}
		else
		{
			levelIndexWasWas = levelIndexWas;
			levelIndexWas = currentLevelIndex;
		}

		if (levelNumber == 6)
		{
			currentLevel = InstantiateRandom(shop1);
			levelNumber++;
		}
		else if (levelNumber == 12)
		{
			currentLevel = InstantiateRandom(shop2);
			levelNumber++;
		}
		else if (levelNumber == 18)
		{
			currentLevel = InstantiateRandom(shop3);
			levelNumber++;
		}
		else if (levelNumber == 24)
		{
			currentLevel = InstantiateRandom(shop4);
			levelNumber++;
		}
		else if (levelNumber == 30)
		{
			currentLevel = InstantiateRandom(boss);
			levelNumber++;
		}
		else if (levelNumber == 0)
		{
			currentLevel = Instantiate(startLevel);
			levelNumber++;
		}
		else if (levelNumber >= 1 && levelNumber <= 5)
		{
			currentLevel = InstantiateRandom(levels1);
			levelNumber++;
		}
		else if (levelNumber >= 7 && levelNumber <= 11)
		{
			currentLevel = InstantiateRandom(levels2);
			levelNumber++;
		}
		else if (levelNumber >= 13 && levelNumber <= 17)
		{
			currentLevel = InstantiateRandom(levels3);
			levelNumber++;
		}
		else if (levelNumber >= 19 && levelNumber <= 23)
		{
			currentLevel = InstantiateRandom(levels4);
			levelNumber++;
		}
		else if (levelNumber >= 25 && levelNumber <= 29)
		{
			currentLevel = InstantiateRandom(levels5);
			levelNumber++;
		}
	}

	private GameObject InstantiateRandom(GameObject[] levelArray)
	{
		int randomIndex = Random.Range(0, levelArray.Length);

		while (randomIndex == levelIndexWas || randomIndex == levelIndexWasWas)
		{
			randomIndex = Random.Range(0, levelArray.Length);
		}

		currentLevelIndex = randomIndex;

		return Instantiate(levelArray[currentLevelIndex]);
	}

	public void RestartLevel()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}
}