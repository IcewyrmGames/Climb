using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour {
	public float acceleration = 20f;
	public float moveSpeed = 8f;
	public float jumpSpeed = 10f;
	public float gravity = 20f;

	public float rotSpeed = 10f;

	CharacterController controller;
	Vector3 inputDirection;
	Vector3 moveVelocity;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update() {
		moveVelocity = controller.velocity; //get the velocity from the previous frame
		moveVelocity.z = 0f; //to prevent drifting into the z axis
		inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //this doesn't technically need to be a vector3

		if (inputDirection.sqrMagnitude > .01f) {
			//if we have a direction, move towards it using our acceleration rate
			moveVelocity.x = Mathf.MoveTowards(moveVelocity.x, inputDirection.x * moveSpeed, acceleration * Time.deltaTime);
		} else {
			//if we have no input, slow to 0
			moveVelocity.x = Mathf.MoveTowards(moveVelocity.x, 0f, acceleration * Time.deltaTime);
		}

		if (controller.isGrounded) {
			if (Input.GetButton("Jump")) {
				//moveVelocity.y += jumpSpeed; //this will make the player launch very high when jumping up an incline.
				moveVelocity.y = jumpSpeed; //sets absolute cap on jump height, even on slopes.
			} else {
				//ground correction to prevent hopping down slopes
				moveVelocity.y = -.2f;
			}
		} else {
			//apply gravity when in the air
			moveVelocity.y -= gravity * Time.deltaTime;
		}

		//move the controller using our desired velocity
		controller.Move(moveVelocity * Time.deltaTime);

		if (controller.velocity.x != 0f) {
			//always rotates towards the camera
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 91f*(Mathf.Sign(controller.velocity.x)-1f), 0), rotSpeed * Time.deltaTime);
		}
	}
}
