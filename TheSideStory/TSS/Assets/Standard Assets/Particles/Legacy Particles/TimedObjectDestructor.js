var timeOut = 1.0;
var detachChildren = false;

// This script allows an object to destroy itself in certain amount of time
function Awake ()
{
	Invoke ("DestroyNow", timeOut);
}

// Destroys the object
function DestroyNow ()
{
	if (detachChildren) {
		transform.DetachChildren ();
	}
	DestroyObject (gameObject);
}