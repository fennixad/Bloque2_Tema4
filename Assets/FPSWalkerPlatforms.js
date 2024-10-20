var speed = 6.0;
var jumpSpeed = 8.0;
var gravity = 20.0;
var platform : Transform;
private var lastPlatformPosition : Vector3;

private var moveDirection = Vector3.zero;
private var grounded : boolean = false;


function FixedUpdate() {
	var platformDelta = Vector3.zero;
	if (platform)
	{
		platformDelta = platform.position - lastPlatformPosition;
		lastPlatformPosition = platform.position;
	}

	if (grounded) {
		// We are grounded, so recalculate movedirection directly from axes
		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		moveDirection = transform.TransformDirection(moveDirection);
		moveDirection *= speed;
		
		if (Input.GetButton ("Jump")) {
			moveDirection.y = jumpSpeed;
			// moveDirection is time independent so we need to convert the platform delta to that
			moveDirection += platformDelta / Time.deltaTime;
		}
	}

	// Apply gravity
	moveDirection.y -= gravity * Time.deltaTime;


	// Move the controller
	var controller : CharacterController = GetComponent(CharacterController);
	var totalMove = moveDirection * Time.deltaTime;

	if (grounded)
		totalMove += platformDelta;

	var flags = controller.Move(totalMove);
	grounded = (flags & CollisionFlags.CollidedBelow) != 0;
}

function OnTriggerEnter(col : Collider)
{
	// Ignore trigger vs self events
	if (col.transform == this)
		return;

	platform = col.transform;
	lastPlatformPosition = platform.position;
}

function OnTriggerExit(col : Collider)
{
	if (col.transform == platform)
		platform = null;
}

function Awake ()
{
	var controller : CharacterController = GetComponent(CharacterController);
	if (!controller)
		gameObject.AddComponent("CharacterController");
}