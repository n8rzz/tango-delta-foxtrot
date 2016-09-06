using UnityEngine;

public class UndoLastMoveButtonController : MonoBehaviour 
{
	public bool isEnabled = false;
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
			shouldUndoLastMove = false;

			changeButtonState(isEnabled);
		}
	}

	// onClick handler for undo button.
	// changes shouldUndoLastMove which is watched by GameController.Update(). changing this prop to true
	// will initiate the process to undo the last player move.
	public void onClickUndoButton()
	{
		if (isEnabled) {
			shouldUndoLastMove = true;
		}
	}

	// change the current state of the button
	private void changeButtonState(bool nextState)
	{
		undoLastMoveButton.SetActive(isEnabled);
	}
}
