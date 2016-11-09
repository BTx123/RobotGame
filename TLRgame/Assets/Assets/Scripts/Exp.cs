using UnityEngine;
using System.Collections;

public class Exp : MonoBehaviour {

	[SerializeField]
	private PlayerStats player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag("Player")) {
			player.Experience(10);
		}
	}

}
