using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void StartGame ()
    {
        //used to load the game and reset the game
        SceneManager.LoadScene("GameScene");	
	}
	
	public void EndGame ()
    {
        //Used to go to the end screen
        SceneManager.LoadScene("EndScene");
	}

    public void MenuReturn ()
    {
        //Used to return to the opening screen
        SceneManager.LoadScene("WelcomeScene");
    }

    public void QuitGame ()
    {
        //Used to quit the game
        Application.Quit();
    }
}
