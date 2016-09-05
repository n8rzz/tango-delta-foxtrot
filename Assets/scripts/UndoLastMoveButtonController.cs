using UnityEngine;

public class UndoLastMoveButtonController : MonoBehaviour 
{
	private bool isEnabled = false;

	public bool shouldUndoLastMove = false;
	public GameObject undoLastMoveButtonController;
	public GameObject undoLastMoveButton;


	// Unity lifecycle method
	void Start () 
	{
		isEnabled = false;
		undoLastMoveButtonController = GameObject.FindGameObjectWithTag("undoLastMoveButtonController").gameObject;
		undoLastMoveButton = GameObject.FindGameObjectWithTag("undoLastMoveButton").gameObject;
		
		changeButtonState(isEnabled);
	}


	// enable the button and show it in the view
	public void enable()
	{
		if (!isEnabled)
		{
			isEnabled = true;
			shouldUndoLastMove = false;
			changeButtonState(isEnabled);
		}
	}

	// disable the button and remove it from the view
	public void disable()
	{
		if (isEnabled)
		{
			isEnabled = false;
			changeButtonState(isEnabled);
		}
	}

	// change the current state of the button
	private void changeButtonState(bool nextState)
	{
		undoLastMoveButton.SetActive(isEnabled);
	}


	//
	public void onClickUndoButton()
	{
		Debug.Log("--- click");
		shouldUndoLastMove = true;

		disable();
	}
}
