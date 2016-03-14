using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public void ChangeScene (string sceneToChange) {
		Application.LoadLevel(sceneToChange);
		
	}
}