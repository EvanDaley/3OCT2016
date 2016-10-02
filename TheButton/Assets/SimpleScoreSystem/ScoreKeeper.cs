using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public float scoreBoostInterval = 1f;	// increment the score by scoreIntervalAmount every scoreBoostInterval seconds
	public int scoreIntervalAmount = 1;		// how many points we add every x seconds (where x is scoreBoostInterval)
	private float scoreBoostCooldown;		// a timer set based on scoreBoostInterval. See update method. 

	private bool freezeScore = false;		// freeze the score when the player dies

	public static ScoreKeeper Instance;		// a reference to this singleton
	private int cash;						// current score of player
	private int record;						// the highest recorded score of the player

	// cash game variables
	public int buttonMultiplier = 1;
	public float buttonUpgradeCostFactor = 1f;

	void Awake()
	{
		Instance = this;
	}

	void Start () 
	{
		// reset playerprefs
		PlayerPrefs.SetInt ("cash", 0);
		PlayerPrefs.SetInt ("record", 0);

		cash = PlayerPrefs.GetInt ("cash", 0);
		record = PlayerPrefs.GetInt ("record", 0);
	}

	void Update()
	{
		if (Time.time > scoreBoostCooldown)
		{
			scoreBoostCooldown = Time.time + scoreBoostInterval;
			AddScore (buttonMultiplier);
		}
	}

	public void AddScore(int points)
	{
		cash += points;
		record += points;

		PlayerPrefs.SetInt ("cash", cash);
		PlayerPrefs.SetInt ("record", record);
	}

	public void PushButton()
	{
		AddScore (buttonMultiplier);
	}

	public int Score
	{
		get{ return record; }
	}

	public int Record
	{
		get{ return cash; }
	}

	public int ButtonCost
	{

	}
}
