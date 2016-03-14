using UnityEngine;
using System.Collections;

public class TriggerCivilian : MonoBehaviour {

	private GameObject civilian;
	int counter = 0;

	void Awake(){
		civilian = GameObject.FindGameObjectWithTag ("civilian");
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.gameObject.name == "Civilian") {
			col.GetComponent<MoveCivilian> ().enabled = true;
		}
	}

	void UpdateScore(){
		if (civilian.GetComponent<MoveCivilian> ().enabled) {
			counter = counter + 50;
		}
	}


}