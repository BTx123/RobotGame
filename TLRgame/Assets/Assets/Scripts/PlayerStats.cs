using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public Stat health;

	public Stat exp;


	private void Awake()
	{
		health.Initialize();
		exp.Initialize();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
		{
			health.CurrentVal -= 10;
		}
	}

	public void Damage(int dmg) {
		health.CurrentVal -= 10;
		print("dmg");
	}
}
