using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public float scoreBoostInterval = 1f;	// increment the score by scoreIntervalAmount every scoreBoostInterval seconds
	public int scoreIntervalAmount = 1;		// how many points we add every x seconds (where x is scoreBoostInterval)
	private float scoreBoostCooldown;		// a timer set based on scoreBoostInterval. See update method. 

	public static ScoreKeeper Instance;		// a reference to this singleton
	private int cash;						// current score of player
	private int record;						// the highest recorded score of the player

	// cash game variables
	public float mult = 1;
	public float costFactor = 1f;

	void Awake()
	{
		Instance = this;
	}

	void Start () 
	{
		// reset playerprefs for testing
//		PlayerPrefs.SetInt ("cash", 0);
//		PlayerPrefs.SetInt ("record", 0);
//		PlayerPrefs.SetFloat ("mult", 1);
//		PlayerPrefs.SetFloat ("costFactor", 12);

		cash = PlayerPrefs.GetInt ("cash", 0);
		record = PlayerPrefs.GetInt ("record", 0);
		mult = PlayerPrefs.GetFloat ("mult", 1);
		costFactor = PlayerPrefs.GetFloat ("costFactor", 1);
	}

	void Update()
	{
		if (Time.time > scoreBoostCooldown)
		{
			scoreBoostCooldown = Time.time + scoreBoostInterval;
			AddScore ((int)Mathf.Floor(mult));
		}
	}

	public void AddScore(int points)
	{
		cash += points;
		record += points;

		PlayerPrefs.SetInt ("cash", cash);
		PlayerPrefs.SetInt ("record", record);
	}

	public void SpendCash(int amount)
	{
		cash -= amount;
	}

	public void PushButton()
	{
		AddScore ((int)Mathf.Floor(mult));
	}

	public void UpgradeButton()
	{
		if (cash >= ButtonCost)
		{
			SpendCash (ButtonCost);
			mult = mult * 1.2f + 1;
			costFactor += .6f;

			PlayerPrefs.SetFloat ("mult", mult);
			PlayerPrefs.SetFloat ("costFactor", costFactor);
		}
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
		get{ return (int)(costFactor * mult); }
	}

	public int ButtonWorth
	{
		get{ return (int)(Mathf.Floor(mult)); }
	}
}
