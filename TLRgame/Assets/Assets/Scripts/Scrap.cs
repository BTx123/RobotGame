using UnityEngine;
using System.Collections;

public class Scrap : MonoBehaviour {
	[SerializeField]
	private int exp = 0;
	private PlayerStats player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag("Player")) {
			Destroy(this.gameObject);
			exp++;
			print("Player Experience: " + exp);
		}
}
}
