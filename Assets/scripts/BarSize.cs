using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarSize : MonoBehaviour {

	public GameObject gaugeInside;

	public int maxSize;
	public int amount;
	private float currentSize;
	private float fullLength;

	void Start ()
	{
		fullLength = (float)245.6;
		CalculateLength (maxSize, amount);
	}

	void Update ()
	{
		CalculateLength (maxSize, amount);
	}

	void CalculateLength (int max, int amount)
	{
		// calculate amount and move bar
		float width = (((float)amount / (float)max) * fullLength);
		print (width);
		// for future reference, these numbers get
		// multiplied the default width and height
		// of the GameObject (1, 53)
		transform.localScale = new Vector2 (width, 1);
	}
}
