using UnityEngine;
using System.Collections;

public class SpringFollow : MonoBehaviour {
	public Transform target;
	public float speed = 20f;

	Vector3 targetPosition;

	// Update is called once per frame
	void Update () {
		if (target.hasChanged) {
			targetPosition = target.position;
		}

		transform.position = Vector3.Lerp(transform.position, targetPosition, .4f * speed * Time.deltaTime);
	}
}
