using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
			Application.LoadLevel("Detection Screen");
	}
}