 using UnityEngine;

public class Zoom : MonoBehaviour
{
	public float zoomSpeed = 0.075f;        // The rate of change of the field of view in perspective mode.

	void Update()
	{
		// If there are two touches on the device...
		if (Input.touchCount == 2) {
		
			// Store both touches.
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Find the position in the previous frame of each touch.
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			// Find the magnitude of the vector (the distance) between the touches in each frame.
			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Find the difference in the distances between each frame.
			float changeby = (prevTouchDeltaMag - touchDeltaMag) * zoomSpeed;

			if (transform.position.y + changeby > 5) {
				transform.localPosition += new Vector3 (changeby * -0.7f,changeby,changeby * -0.7f);
			} else {
				transform.localPosition = new Vector3 (-4f, 5f, -4f);
			}
		}
	}
}
