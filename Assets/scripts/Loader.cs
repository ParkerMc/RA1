using UnityEngine;
using System.Collections;

public class loader : MonoBehaviour {
	public UnityEngine.UI.Button button;

	void Start(){
		button.onClick.AddListener (() => {
			Play ();
		});
	}

	public void Play(){
		Application.LoadLevel(1);
	}

}