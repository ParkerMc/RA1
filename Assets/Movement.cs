using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Touch touchZero = Input.GetTouch(0);

		// Find the position in the previous frame of each touch.
		Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;

		// Find the difference in the distances between each frame.
		float changeby = (touchZeroPrevPos.magnitude - touchZero.position.magnitude) * moveSpeed;
	}
}
