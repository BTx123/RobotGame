using UnityEngine;
using System.Collections;

public class NewLevel : MonoBehaviour {

	public LevelManager levelmanager;
    public GUITexture overlay;
    public float fadeTime;

    void Awake() {
		StartCoroutine(levelmanager.FadeToClear());r
	}

	public IEnumerator FadeToClear()
	{
		overlay.gameObject.SetActive(true);
		overlay.color = Color.black;

		float rate = 1.0f/fadeTime;

		float progress = 0.0f;

		while(progress < 1.0f)
		{
			overlay.color = Color.Lerp(Color.black, Color.clear, progress);
			progress += rate*Time.deltaTime;
			yield return null;
		}

		overlay.color = Color.clear;
		overlay.gameObject.SetActive(false);
	}
}
