using UnityEngine;

public class SpawnGamePost : MonoBehaviour {
	public int postContainerWidth = 4;
	public int postContainerHeight = 4;
	public GameObject boardPost;
	
	private int numberOfRows = 4;
	private int numberOfColumns = 4;

	void Start () 
	{
		for (int y = 0; y < numberOfRows; y++)
		{
			for (int x = 0; x < numberOfColumns; x++)
			{
				GameObject newpost = Instantiate(boardPost, transform.position + x * (transform.right * postContainerWidth) + y * (transform.forward * (-postContainerHeight)), Quaternion.identity) as GameObject;		
				newpost.transform.name = y + "-" + x;
				newpost.transform.parent = GameObject.FindGameObjectWithTag("gameBoardPostContainer").transform;
                newpost.GetComponent<InteractWithGameBoardPost>().gameController = GameObject.FindGameObjectWithTag("gameManager").gameObject;
			}
		}
	}
}
