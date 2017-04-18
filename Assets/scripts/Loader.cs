using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
	public UnityEngine.UI.Button button;

	void Start(){
		button.onClick.AddListener (() => {
			Play ();
		});
	}

	public void Play(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}

}