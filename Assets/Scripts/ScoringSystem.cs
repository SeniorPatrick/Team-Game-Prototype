using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoringSystem : MonoBehaviour {
	
	public Text scoreText;
	private int score = 50;
	
	void Update () {
		scoreText.text = "Score: " + score;
	}
}
