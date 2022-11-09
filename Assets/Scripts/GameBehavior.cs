using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    // 1 = Gyro / 2 = Accelero / 3 = Camera  
    // Variable accessible men ay script
    public static int gameMode;

	public Text topText;
	public GameObject gyroButton;
	public GameObject aceleroButton;
	public GameObject cameraButton;

    void Start()
    {
        gameMode = 0;
    }

    void Update()
    {
        
    }

    public void chooseMode(int modeCode){
        gameMode = modeCode;

        if (modeCode == 1){
            topText.text = "Gyroscope";
        } else if (modeCode == 2){
            topText.text = "Accelerometre";
        } else if (modeCode == 3) {
            topText.text = "Camera";
        }

        gyroButton.SetActive(false);
        aceleroButton.SetActive(false);
        cameraButton.SetActive(false);
    }
}
