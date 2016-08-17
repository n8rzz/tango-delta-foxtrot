using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ResetGameController : MonoBehaviour 
{

	public void resetGame()
	{
//		Debug.Log("RESET!");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
//		Application.LoadLevel(Application.loadedLevel);
	}

}
