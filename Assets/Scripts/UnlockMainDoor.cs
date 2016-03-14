using UnityEngine;
using System.Collections;

public class UnlockMainDoor : MonoBehaviour {

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
		if(col.gameObject.name == "mainKey")
		{
			Destroy(col.gameObject);
			Destroy(prefab2);
			Instantiate(prefab,new Vector3 (posX, posY, -1.4f), Quaternion.identity);
			collected++;
		}
		
		if (col.gameObject.name == "mainDoorpf(Clone)") {
			Destroy (col.gameObject);
			Application.LoadLevel ("Level Over");
		}
	}
}
