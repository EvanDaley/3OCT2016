using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

	public Text scoreText;
	public Text recordText;
	
	void Update () 
	{
		scoreText.text = ScoreKeeper.Instance.Score.ToString();
		recordText.text = ScoreKeeper.Instance.Record.ToString();
	}
}
