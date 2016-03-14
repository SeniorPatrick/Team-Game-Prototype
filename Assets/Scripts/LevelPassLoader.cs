using UnityEngine;
using System.Collections;

public class LevelPassLoader : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.gameObject.name == "Sprite")
			Application.LoadLevel ("Level Over");
	}

}
