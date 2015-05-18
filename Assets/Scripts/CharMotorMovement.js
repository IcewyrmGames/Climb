#pragma strict

var motor : CharacterMotor;
var controller : CharacterController;

function Start () {
	motor = GetComponent(typeof(CharacterMotor));
}

function Update () {
	motor.inputMoveDirection = Vector3(Input.GetAxis("Horizontal"), 0, 0);
	if (Input.GetButton("Jump")) {
		motor.inputJump = true;
	} else {
		motor.inputJump = false;
	}
	
	if (Input.GetButtonDown("Jump")) {
		if (!audio.isPlaying) {
			audio.Play();
		}
	}
}