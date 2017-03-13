using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server {
	public delegate void ReturnFunction(JSONObject json);

	public void SendData(string json, ReturnFunction func){
		WWWForm data = new WWWForm();
		data.AddField ("cmd", json);
		WWW www = new WWW(Settings.url, data);
		MonoBehave.instance.StartCoroutine(WaitForRequest(www, func));
	}

	private IEnumerator WaitForRequest(WWW www, ReturnFunction func){
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!");
			func (new JSONObject(www.text));
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
}
