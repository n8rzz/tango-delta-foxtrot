using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameController : MonoBehaviour 
{
	public void resetGame()
	{
		GameBoardController.resetGameBoard();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
