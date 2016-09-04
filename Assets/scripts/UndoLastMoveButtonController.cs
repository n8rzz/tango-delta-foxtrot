using UnityEngine;
using System.Collections;

public class UndoLastMoveButtonController : MonoBehaviour 
{
	private bool isEnabled = false;

	public GameObject undoLastMoveButtonController;

	void Start () 
	{
		undoLastMoveButtonController = GameObject.FindGameObjectWithTag("undoLastMoveButtonController").gameObject;
	}

	// public void enable()
	// {}

	// public void disable()
	// {}

	public void onClickUndoButton()
	{
		Debug.Log("click undo");
	}

	// private showUndoLastMoveButton()
	// {}

	// private hideUndoLastMoveButton()
	// {}

	// private void initUndo()
	// {}
}
