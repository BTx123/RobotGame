using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	//public Stat health;

	public Stat expTest;

	private void Awake()
	{
		//health.Initialize();
		expTest.Initialize();
	}

	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown(KeyCode.Q))
		//{
			//health.CurrentVal -= 10;
		//}
		if (Input.GetKeyDown(KeyCode.E))
		{
			expTest.CurrentVal += 10;
		}
	}

/*
	public void Damage(int dmg) {
		health.CurrentVal -= dmg;
	}
	*/

	public void Experience(int experience)
	{
		expTest.CurrentVal += experience;
	}
}
