using UnityEngine;
using System.Collections;

public class MoveBox : MonoBehaviour {

	public float moveSpeed;
	
	void Start () {
		moveSpeed = 10f;
	}

	void Update () {
		transform.Translate(moveSpeed*Input.GetAxis("Horizontal")*Time.deltaTime,0f,Input.GetAxis("Vertical")*Time.deltaTime);
	}
}
