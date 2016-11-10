using UnityEngine;
using System.Collections;

public class LevelHandler : MonoBehaviour {

	public GUITexture overlay;
	public float fadeTime;

	public Player player;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag("Player")) {
			StartCoroutine(FadeToBlack());
		}
	}

	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}


	public IEnumerator FadeToBlack()
	{
		overlay.gameObject.SetActive(true);
		overlay.color = Color.clear;

		float rate = 1.0f/fadeTime;

		float progress = 0.0f;

		while(progress < 1.0f)
		{
			overlay.color = Color.Lerp(Color.clear, Color.black, progress);
			progress += rate*Time.deltaTime;
			yield return null;
		}

		overlay.color = Color.black;

		LoadNextLevel();
	}
}
