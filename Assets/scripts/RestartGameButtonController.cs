using UnityEngine;

public class RestartGameButtonController : MonoBehaviour 
{
	public GameObject resetGameController;

	void Start () 
	{
		resetGameController = GameObject.FindGameObjectWithTag("resetGameController").gameObject;
	}

	public void onClickRestartGameButton()
	{
		var resetGameControllerScript = resetGameController.GetComponent<ResetGameController>();
		resetGameControllerScript.resetGame();
	}
}
