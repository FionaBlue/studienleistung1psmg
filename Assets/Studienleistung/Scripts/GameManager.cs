using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //handles the keyDown Methods when winning or losing the game
    //spawns the player to its former position when loading the scene again
   void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
    }
	

}
