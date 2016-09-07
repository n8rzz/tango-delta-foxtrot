using UnityEngine;
using UnityEngine.SceneManagement;

// Reset the current game
public class ResetGameController : MonoBehaviour 
{
	public void resetGame()
	{
		GameBoardController.resetGameBoard();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
