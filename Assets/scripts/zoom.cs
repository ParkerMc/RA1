using UnityEngine;

public class zoom : MonoBehaviour
{
	public float zoomSpeed = 0.3f;        // The rate of change of the field of view in perspective mode.

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
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
			if (transform.position.y + deltaMagnitudeDiff * .5f > 0) {
				transform.localPosition += new Vector3 (-deltaMagnitudeDiff * .5f * zoomSpeed, deltaMagnitudeDiff * .5f * zoomSpeed, 0);
			} else {
				transform.localPosition = new Vector3 (-4f, 0f, -4f);
			}
		}
	}
}
