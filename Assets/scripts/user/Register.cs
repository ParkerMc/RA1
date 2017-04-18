using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Register : MonoBehaviour {

	public UnityEngine.UI.Button button;
	public UnityEngine.UI.Button login;

	public UnityEngine.UI.InputField usernameField;
	public UnityEngine.UI.InputField passwordField;
	public UnityEngine.UI.InputField passwordField2;
	public UnityEngine.UI.InputField emailField;

	// Use this for initialization
	void Start () {
		login.onClick.AddListener (() => {
			Login ();
		});
		button.onClick.AddListener (() => {
			ProcessForm ();
		});
	}

	void Login (){
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}

	void ProcessForm ()
	{

		if (passwordField.text == passwordField2.text) {
			string username = usernameField.text;
			string password = passwordField.text;
			string email = emailField.text;
			Main.server.SendData ("{\"id\":1,\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"email\":\"" + email + "\"}",
				ProcessResponce);
		}
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