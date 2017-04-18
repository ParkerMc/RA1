using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour {

	public UnityEngine.UI.Button button;
	public UnityEngine.UI.Button register;

	public UnityEngine.UI.InputField usernameField;
	public UnityEngine.UI.InputField passwordField;

	// Use this for initialization
	void Start () {
		register.onClick.AddListener (() => {
			Register ();
		});
		button.onClick.AddListener (() => {
			ProcessForm ();
		});
	}

	void Register (){
		UnityEngine.SceneManagement.SceneManager.LoadScene (2);
	}

	void ProcessForm ()
	{
		string username = usernameField.text;
		string password = passwordField.text;
		Main.server.SendData ("{\"id\":2,\"username\":\"" + username + "\",\"password\":\"" + password + "\"}",
			ProcessResponce);
	}

	void ProcessResponce(JSONObject json){
		bool success = json.list[json.keys.IndexOf("success")].b;
		if (success) {
			Main.user.token = json.list [json.keys.IndexOf ("token")].str;
			Main.user.username = json.list [json.keys.IndexOf ("username")].str;
			UnityEngine.SceneManagement.SceneManager.LoadScene (3);
		} else {
			print ("Someting whent wrong:" + json.list[json.keys.IndexOf("msg")].str);
		}
	}
}