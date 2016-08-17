using UnityEngine;
using System.Collections;

public class RestartGameButtonController : MonoBehaviour 
{

	public GameObject resetGameController;

	void Start () 
	{
		resetGameController = GameObject.FindGameObjectWithTag("resetGameController").gameObject;
	}

	public void onClickRestartGameButton()
	{
//		Debug.Log("Click!");

		var resetGameControllerScript = resetGameController.GetComponent<ResetGameController>();
		resetGameControllerScript.resetGame();
	}

}
