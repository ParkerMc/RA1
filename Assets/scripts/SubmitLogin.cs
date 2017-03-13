using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitLogin : MonoBehaviour {

	public UnityEngine.UI.Button button;

	public UnityEngine.UI.InputField usernameField;
	public UnityEngine.UI.InputField passwordField;
	public UnityEngine.UI.InputField emailField;

	private string username;
	private string password;
	private string email;
	// Use this for initialization
	void Start () {
		username = null;
		password = null;
		button.onClick.AddListener (() => {
			ProcessForm ();
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ProcessForm ()
	{
		username = usernameField.text;
		password = passwordField.text;
		email = emailField.text;
		SendData ();
	}

	void SendData ()
	{
		WWWForm data = new WWWForm();
		data.AddField("cmd", "{\"id\":1,\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"email\":\"" + email + "\"}");
		string url = "https://parkermc.ddns.net/RA1/server/cmd.php";
		WWW www = new WWW(url, data);
	}
}
