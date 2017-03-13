using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehave : MonoBehaviour {
	public static MonoBehave instance;

	void Awake()
	{
		instance = this;
	}

	public void StartChildCoroutine(IEnumerator coroutineMethod)
	{
		StartCoroutine(coroutineMethod);
	}
}
