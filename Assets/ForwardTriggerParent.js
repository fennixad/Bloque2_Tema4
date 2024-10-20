function OnTriggerEnter(col)
{
	transform.parent.SendMessage("OnTriggerEnter", col);
}

function OnTriggerExit(col)
{
	transform.parent.SendMessage("OnTriggerExit", col);
}
