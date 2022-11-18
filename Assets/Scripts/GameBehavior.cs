using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
	// 0 = Swipe / 1 = Accelerometre / 2 = Camera / 3 = Voice  
	// Variable accessible men ay script
	public static int gameMode;
	public static bool gameRunning = false;

	public Text topText;
	public GameObject menu;
	public GameObject restartButton;

	private bool lost = false;

	void Start()
	{
		gameMode = 0;
	}

	void Update()
	{
		if (!gameRunning)
		{
			menu.SetActive(true);
		}
	}

	public void chooseMode(int modeCode)
	{
		gameMode = modeCode;

		if (modeCode == 0)
		{
			topText.text = "Swipe";
		}
		else if (modeCode == 1)
		{
			topText.text = "Accelerometre";
		}
		else if (modeCode == 2)
		{
			ObstacleBehavior.itemsSpeed = 2;
			topText.text = "Camera";
		}
		else if (modeCode == 3)
		{
			ObstacleBehavior.itemsSpeed = 1;
			Environement.isHard = false;
			Environement.isVoice = true;

			topText.text = "Voice";
		}

		menu.SetActive(false);

		startGame();
	}

	public static void startGame()
	{

		gameRunning = true;
		resetGame();
	}

	public static void stopGame()
	{
		ObstacleBehavior.itemsSpeed = 6;
		Environement.isHard = true;
		Environement.isVoice = false;

		gameRunning = false;
	}

	private static void resetGame()
	{
		GameObject player = GameObject.FindGameObjectWithTag("player");

		player.transform.position = new Vector3(0, 0, player.transform.position.z);
		GameObject[] environementObjects = GameObject.FindGameObjectsWithTag("obstacle");
		foreach (GameObject environementObject in environementObjects)
		{
			Destroy(environementObject);
		}
	}
}
