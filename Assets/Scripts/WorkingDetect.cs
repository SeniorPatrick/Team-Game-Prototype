using UnityEngine;
using System.Collections;

public class WorkingDetect : MonoBehaviour {
	[Range(0.1f, 10f)]
	public float radius = 1;
	
	[Range(1.0f, 360f)]
	public int fov = 90;

	bool turn = false;
	public Vector2 direction = Vector2.right;
	//object position
	public Transform playerPos;
	//player object
	private GameObject player;
	//enemy object
	private GameObject enemy;
	//enemy position
	Vector2 enemyPos;
	//left and right enemy view
	private Vector2 leftLineFOV;
	private Vector2 rightLineFOV;
	
	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Character");
		enemy = GameObject.FindGameObjectWithTag ("enemy");
		
		enemyPos = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
		RaycastHit2D hit = Physics2D.Raycast (enemyPos, Vector2.zero);
	}
	
	void Update() {
		if(playerPos != null) {
			//creates the right sided view of the enemy from the radius
			rightLineFOV = RotatePointAroundTransform(direction.normalized*radius, -fov/2);
			//creates the left sided view of the enemy from the radius
			leftLineFOV = RotatePointAroundTransform(direction.normalized*radius, fov/2);
			//assigns the players position to the test point
			InsideFOV(new Vector2(playerPos.position.x, playerPos.position.y));
			
			/*if(hit.collider != null){
				Debug.Log(hit.collider.name);
			}*/
		}
	}
	//Checks to see if the player is in the field of view and destroys him
	public bool InsideFOV(Vector2 playerPos) {
		
		float squaredDistance = ((playerPos.x - transform.position.x)*(playerPos.x - transform.position.x)) + ((playerPos.y-transform.position.y)*(playerPos.y-transform.position.y));
		
		if(radius * radius >= squaredDistance) {
			float signLeftLine = (leftLineFOV.x) * (playerPos.y - transform.position.y) - (leftLineFOV.y) * (playerPos.x-transform.position.x);
			float signRightLine = (rightLineFOV.x) * (playerPos.y - transform.position.y) - (rightLineFOV.y) * (playerPos.x-transform.position.x);
			
			if(fov <= 180) {
				if(signLeftLine <= 0 && signRightLine >= 0){
					Application.LoadLevel("Detection Screen");
					//Destroy(player);
					return true;
				}
			} else {
				if(!(signLeftLine >= 0 && signRightLine <= 0)){
					Application.LoadLevel("Detection Screen");
					//Destroy(player);
					return true;
				}
			}
		}
		//returns false if the player is not in the field of view
		return false;
	}
	//Used to create the arc around the radius for the field of view
	private Vector2 RotatePointAroundTransform(Vector2 p, float angles) {
		return new Vector2(Mathf.Cos((angles)  * Mathf.Deg2Rad) * (p.x) - Mathf.Sin((angles) * Mathf.Deg2Rad) * (p.y),
		                   Mathf.Sin((angles)  * Mathf.Deg2Rad) * (p.x) + Mathf.Cos((angles) * Mathf.Deg2Rad) * (p.y));
	}
	
	//Displays the enemys field of view
	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawRay(transform.position, direction.normalized*radius);
		
		rightLineFOV = RotatePointAroundTransform(direction.normalized*radius, -fov/2);
		leftLineFOV = RotatePointAroundTransform(direction.normalized*radius, fov/2);
		
		Gizmos.color = Color.yellow;
		//draws the right and left side of the enemy view
		Gizmos.DrawRay(transform.position, rightLineFOV);
		Gizmos.DrawRay(transform.position, leftLineFOV);
		
		Vector2 p = rightLineFOV;
		
		//adds the curve to the field of view
		for(int i = 1; i <= 20; i++) {
			float step = fov/20;
			Vector2 p1 = RotatePointAroundTransform(direction.normalized*radius, -fov/2 + step*(i));
			Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y) + p, p1-p);
			p = p1;
		}
		Gizmos.DrawRay(new Vector2(transform.position.x, transform.position.y) + p, leftLineFOV - p);
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if(col.gameObject.name == "Basic-Wall-Sprite-(Black)-for-web" && turn == false)
		{
			turn = true;
			direction = -Vector2.right;
		}
		else if(col.gameObject.name == "Basic-Wall-Sprite-(Black)-for-web" && turn == true)
		{
			turn = false;
			direction = Vector2.right;
		}
		
	}
}
