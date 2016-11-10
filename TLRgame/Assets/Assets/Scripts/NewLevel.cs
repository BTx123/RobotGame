using UnityEngine;
using System.Collections;

public class NewLevel : MonoBehaviour {

	public LevelManager levelmanager;

	void Awake() {
		StartCoroutine(levelmanager.FadeToClear());
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
