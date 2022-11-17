using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
	// 0 = Keyboard / 1 = Gyro / 2 = Accelero / 3 = Camera  
	// Variable accessible men ay script
	public static int gameMode;
	public static bool gameRunning = false;

	public Text topText;
	public GameObject menu;

	void Start()
	{
		gameMode = 0;
	}

	void Update()
	{

	}

	public void chooseMode(int modeCode)
	{
		gameMode = modeCode;

		if (modeCode == 1)
		{
			topText.text = "Gyroscope";
		}
		else if (modeCode == 2)
		{
			topText.text = "Accelerometre";
		}
		else if (modeCode == 3)
		{
			topText.text = "Camera";
		}
		else if (modeCode == 4)
		{
			topText.text = "Voice";
		}
		else
		{
			topText.text = "Keyboard";
		}

		menu.SetActive(false);

		startGame();
	}

	public static void startGame()
	{
		gameRunning = true;
	}

	public static void stopGame()
	{
		gameRunning = false;
	}
}
