using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

	public Text scoreText;
	public Text recordText;
	public Text upgradeCostText;
	public Text buttonWorth;

	
	void Update () 
	{
		scoreText.text = ScoreKeeper.Instance.Score.ToString();
		recordText.text = ScoreKeeper.Instance.Record.ToString();
		upgradeCostText.text = "$" + ScoreKeeper.Instance.ButtonCost.ToString();
		buttonWorth.text = "Income: " + ScoreKeeper.Instance.ButtonWorth.ToString();

	}
}
