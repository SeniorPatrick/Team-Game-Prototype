using UnityEngine;
using System.Collections;

public class MoveCivilian : MonoBehaviour {

	public bool flag = false;
	public Transform target;
	public float speed = 1;

	void Update () 
	{
		Vector3 targetDir = target.position - transform.position;
		float step = speed * (Time.deltaTime*3);
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		transform.rotation = Quaternion.LookRotation(newDir);
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		//transform.Rotate (Vector3.forward, -1);
	}

	/*void OnTriggerEnter2D(Collider2D col) 
	{
		if(col.gameObject.name == "Character")
		{
			Vector3 targetDir = target.position - transform.position;
			float step = speed * (Time.deltaTime*3);
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
			transform.rotation = Quaternion.LookRotation(newDir);
			transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		}
	}*/
}