using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using KKSpeech;
using UnityEngine.Events;
using UnityEngine.Android;

namespace KKSpeech
{
	/*
	   * check readme.pdf before using!
	   */
	public class SpeechRecognizerListener : MonoBehaviour
	{

		[System.Serializable]
		public class AuthorizationCallback : UnityEvent<AuthorizationStatus> { };

		[System.Serializable]
		public class ResultCallback : UnityEvent<string> { };

		[System.Serializable]
		public class AvailabilityCallback : UnityEvent<bool> { };

		[System.Serializable]
		public class ErrorCallback : UnityEvent<string> { };

		[System.Serializable]
		public class SupportedLanguagesCallback : UnityEvent<List<LanguageOption>> { };

		public SupportedLanguagesCallback onSupportedLanguagesFetched = new SupportedLanguagesCallback();
		public AuthorizationCallback onAuthorizationStatusFetched = new AuthorizationCallback();
		public ResultCallback onPartialResults = new ResultCallback();
		public ResultCallback onFinalResults = new ResultCallback();
		// iOS-only
		public AvailabilityCallback onAvailabilityChanged = new AvailabilityCallback();
		public ErrorCallback onErrorDuringRecording = new ErrorCallback();
		public ErrorCallback onErrorOnStartRecording = new ErrorCallback();
		// Android-only
		public UnityEvent onEndOfSpeech = new UnityEvent();
		public UnityEvent onReadyForSpeech = new UnityEvent();

		private void Start()
		{
			if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
			{
				Permission.RequestUserPermission(Permission.Microphone);
			}
		}

		bool isStarted = false;

		private void Update()
		{
			if (GameBehavior.gameRunning && !isStarted)
			{
				SpeechRecognizer.StartRecording(true);
				isStarted = true;
			}
		}

		void AvailabilityDidChange(string available)
		{
			Debug.Log("SPEECH RECOGNIZER : AvailabilityDidChange " + available);
			onAvailabilityChanged.Invoke(available.Equals("1"));
		}

		void GotPartialResult(string result)
		{
			Debug.Log("SPEECH RECOGNIZER : GotPartialResult " + result);
			onPartialResults.Invoke(result);
		}

		void GotFinalResult(string result)
		{
			Debug.Log("SPEECH RECOGNIZER : GotFinalResult " + result);
			SpeechRecognizer.StopIfRecording();
			if (result == "saute")
			{
				PlayerBehavior.jump = true;
			}

			if (result == "droite")
			{
				PlayerBehavior.right = true;
			}

			if (result == "gauche")
			{
				PlayerBehavior.left = true;
			}
			SpeechRecognizer.StartRecording(true);

			onFinalResults.Invoke(result);
		}

		void FailedToStartRecording(string reason)
		{
			Debug.Log("SPEECH RECOGNIZER : FailedToStartRecording " + reason);
			onErrorOnStartRecording.Invoke(reason);
		}

		void FailedDuringRecording(string reason)
		{
			Debug.Log("SPEECH RECOGNIZER : FailedDuringRecording " + reason);
			SpeechRecognizer.StopIfRecording();
			SpeechRecognizer.StartRecording(true);

			onErrorDuringRecording.Invoke(reason);
		}

		public void SupportedLanguagesFetched(string langs)
		{
			string[] components = langs.Split('|');

			List<LanguageOption> languageOptions = new List<LanguageOption>();
			foreach (string component in components)
			{
				string[] idAndName = component.Split('^');
				var option = new LanguageOption(idAndName[0], idAndName[1]);
				languageOptions.Add(option);
			}

			onSupportedLanguagesFetched.Invoke(languageOptions);
		}

		// Android-only
		void OnEndOfSpeech(string dummy)
		{
			Debug.Log("SPEECH RECOGNIZER : End Of Speech");
			Debug.Log("The speech : " + dummy);
			onEndOfSpeech.Invoke();
		}

		void OnReadyForSpeech(string dummy)
		{
			Debug.Log("SPEECH RECOGNIZER : Ready For Speech");
			onReadyForSpeech.Invoke();
		}

		void AuthorizationStatusFetched(string status)
		{
			Debug.Log("SPEECH RECOGNIZER : AuthorizationStatusFetched" + status);
			AuthorizationStatus authStatus = AuthorizationStatus.NotDetermined;
			switch (status)
			{
				case "denied":
					authStatus = AuthorizationStatus.Denied;
					break;
				case "authorized":
					authStatus = AuthorizationStatus.Authorized;
					break;
				case "restricted":
					authStatus = AuthorizationStatus.Restricted;
					break;
				case "notDetermined":
					authStatus = AuthorizationStatus.NotDetermined;
					break;
			}

			onAuthorizationStatusFetched.Invoke(authStatus);
		}
	}
}
