using UnityEngine;
using System.Collections;

public class EnemyPath : MonoBehaviour {

	bool turn = false;
	public GameObject nme, nmelt;
	public float ms = 0.03f;
	public GameObject enemy;
	
	void Update () 
	{
		Vector3 newPosition = enemy.transform.position;
		newPosition.x = newPosition.x+ms;
		enemy.transform.position = newPosition;
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if(col.gameObject.name == "Basic-Wall-Sprite-(Black)-for-web" && turn == false)
		{
			turn = true;
			nme.transform.Rotate(0,180,0);
			nmelt.transform.Rotate(0,180,0);
			ms = -0.03f;
		}
		else if(col.gameObject.name == "Basic-Wall-Sprite-(Black)-for-web" && turn == true)
		{
			turn = false;
			nme.transform.Rotate(0,180,0);
			nmelt.transform.Rotate(0,180,0);
			ms = 0.03f;
		}

	}
}
