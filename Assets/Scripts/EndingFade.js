#pragma strict

public var movement : CharMotorMovement;
public var motor : CharacterMotor;
public var anim : Animation;

function OnTriggerEnter() {
	movement.enabled = false;
	motor.inputMoveDirection = Vector3(-1,0,0);
	anim.Play();
}