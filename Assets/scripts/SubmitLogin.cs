using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitLogin : MonoBehaviour {

	public UnityEngine.UI.Button button;

	public UnityEngine.UI.InputField usernameField;
	public UnityEngine.UI.InputField passwordField;
	public UnityEngine.UI.InputField emailField;

	public string username;
	public string token;
	private string password;
	private string email;

	// Use this for initialization
	void Start () {
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
		SendData();
	}

	void ProcessResponce(string responce){
		JSONObject json = new JSONObject(responce);
		bool success = json.list[json.keys.IndexOf("success")].b;
		if (success) {
			token = json.list [json.keys.IndexOf ("token")].str;
			username = json.list [json.keys.IndexOf ("username")].str;
		} else {
			print ("Someting whent wrong:" + json.list[json.keys.IndexOf("msg")].str);
		}
	}


	void SendData ()
	{
		WWWForm data = new WWWForm();
		data.AddField("cmd", "{\"id\":1,\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"email\":\"" + email + "\"}");
		string url = "https://parkermc.ddns.net/RA1/server/cmd.php";
		WWW www = new WWW(url, data);
		StartCoroutine(WaitForRequest(www));
	}
	private IEnumerator WaitForRequest(WWW www){
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			ProcessResponce (www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
}