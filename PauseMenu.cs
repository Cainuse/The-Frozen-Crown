using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;              //this enables us to show or not show the UI
	public GameObject HUD;

    private bool paused = false;            //this will make this exclusive to this script

    void Start()                            //this function disables the PauseUI
    {
        PauseUI.SetActive(false);
		HUD.SetActive (true);
    }
	
    void Update()
    {
        if (Input.GetButtonDown("Pause"))   //when we press the pause button        I went to edit,project setting, input and made a button
        {
            paused = !paused;               //it makes the current bool be true thus enabling menu
        }

        if (paused)
        {
            PauseUI.SetActive(true);        //This puts up the menu screen
			HUD.SetActive(false);		//This disables the Hud
            Time.timeScale = 0;             //setting the time to zero, frezzing or pausing the game

        }

        if (!paused)
        {
            PauseUI.SetActive(false);       //This takes away the menu
			HUD.SetActive(true);		//This reenables the HUD
            Time.timeScale = 1;             //This alows time to continue as it once was so 1 = normal 0 = stop
        }



    }

    public void Resume()                    //This function will be enabled on the resume button
    {
        paused = false;                     //By pressing th button the function will run thus resuming the game
    }

    public void Restart()                   //This function will be enabled on the restart button
    {
        Application.LoadLevel(Application.loadedLevel);         // this reloads the current level to its default start
    }

    public void MainMenu()                  //This function will be enabled on the Main Menu button
    {
        Application.LoadLevel(0);                               //This goes to the first scene in out case the main menu
    }

    public void Quit()                      //This function will be enabled on the Quit button
    {
        Application.Quit();
    }

}
