using UnityEngine;
using System.Collections;

public class UnlockDoor : OpenDoor {

	public static int collected = 0;
	public GameObject prefab, prefab2;
	public float posX, posY;

	void Start () 
	{
		posX = prefab2.transform.position.x;
		posY = prefab2.transform.position.y;
	}
	
	void OnTriggerEnter2D(Collider2D col) 
	{
		if(col.gameObject.name == "key")
		{
			Destroy(col.gameObject);
			Destroy(prefab2);
			Instantiate(prefab,new Vector3 (posX, posY, -1.4f), Quaternion.identity);
			collected++;
		}
		
		if(col.gameObject.name == "door(Clone)")
			Destroy(col.gameObject);

	}
}
