using UnityEngine;
using System.Collections;

public class NewLevel : MonoBehaviour {

	public LevelHandler levelhandler;

	void Awake() {
		StartCoroutine(levelhandler.FadeToClear());
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
