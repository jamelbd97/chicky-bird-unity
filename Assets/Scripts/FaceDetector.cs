using OpenCvSharp;
using UnityEngine;

public class FaceDetector : MonoBehaviour
{
	public static float x;
	public static float y;

	WebCamTexture _webCamTexture;
	CascadeClassifier cascadeClassifier;

	void Start()
	{
		WebCamDevice[] devices = WebCamTexture.devices;

		_webCamTexture = new WebCamTexture(devices[0].name);
		_webCamTexture.Play();

		cascadeClassifier = new CascadeClassifier(Application.dataPath + @"/haarcascade_frontalface_default.xml");
	}

	void Update()
	{
		GetComponent<Renderer>().material.mainTexture = _webCamTexture;
		Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);

		findNewFace(frame);
	}

	void findNewFace(Mat frame)
	{
		var faces = cascadeClassifier.DetectMultiScale(frame, 1.1, 2, HaarDetectionType.ScaleImage);

		if (faces.Length >= 1)
		{
			x = faces[0].X;
			y = faces[0].Y;
		}
	}
}
