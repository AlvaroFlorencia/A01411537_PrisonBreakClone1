using UnityEngine;
using UnityEngine.SceneManagement;		// Requiered to switch scenes
using System.Collections;

//	This class will help us control how our game's scenes flow
public class LevelManager : MonoBehaviour {
	public int bricks = Brick.breakableCount;
	public int CurrentSceneIndex;

	void Update () {
	CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		bricks = Brick.breakableCount;
		if (bricks == 0 && CurrentSceneIndex>2 ) {  //If the Current scene is gretaer than 2 ,the conitninue with the process of las next level until the last secen Win
			LoadNextLevel ();
		}
		if (bricks == 0 && CurrentSceneIndex==2 ) { //is is 2,then is the default level,the next scene will be Win
			LoadLevel ("Win");
		}
	}
	public void LoadLevel(string name){
		
        //  Reset the number of breakable bricks in the scene to 0


        //  Load the scene requested
		//  Debug.Log ("New Level load: " + name);
		//	Application.LoadLevel (name);    -- This method was deprecated a long time ago
		SceneManager.LoadScene (name);
	}

	public void EndGame(){
		//  Debug.Log ("Quit requested");
		Application.Quit ();
	}

    //  We added these functions to our previous LevelManager script.
    public void LoadNextLevel(){
        //  Reset the number of breakable bricks in the scene to 0


		Brick.breakableCount = 0;

		//  Load the next scene in the build order
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}
