using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) 
	{
		if(col.gameObject.name == "door")
			Destroy(col.gameObject);

		if(col.gameObject.name == "ceiling")
			Destroy(col.gameObject);

	}
}