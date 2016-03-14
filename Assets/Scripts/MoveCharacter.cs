using UnityEngine;
using System.Collections;

public class MoveCharacter : MonoBehaviour {

	public float moveSpeed = 0.05f;
	public GameObject character;

	void Update () 
	{
		if (Input.GetKey(KeyCode.RightArrow)){
			
			Vector3 newPosition = character.transform.position;
			newPosition.x = newPosition.x+moveSpeed;
			character.transform.position = newPosition;
		}
		if (Input.GetKey(KeyCode.LeftArrow)){
			
			Vector3 newPosition = character.transform.position;
			newPosition.x = newPosition.x-moveSpeed;
			character.transform.position = newPosition;
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			
			Vector3 newPosition = character.transform.position;
			newPosition.y = newPosition.y + moveSpeed;
			character.transform.position = newPosition;
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			
			Vector3 newPosition = character.transform.position;
			newPosition.y = newPosition.y - moveSpeed;
			character.transform.position = newPosition;
		}

	}
}
