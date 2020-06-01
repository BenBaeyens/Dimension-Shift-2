using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteAlways]
public class MenuScript : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject optionsMenu;
    public GameObject creditsMenu;
    public GameObject changelogMenu;

    #region MainMenu

    public void PlayButton(){
        
        // TODO: Animation

        //TEMP:
        mainMenu.SetActive(false);
        playMenu.SetActive(true);
    }



    public void OptionsButton(){

        // TODO: Animation

        //TEMP:
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CreditsButton(){
        
        //TODO: Animation

        //TEMP:
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void ChangelogButton(){
        
        //TODO: Animation

        //TEMP:
        mainMenu.SetActive(false);
        changelogMenu.SetActive(true);
    }


    public void BackButton(){

        // TODO: Animation

        //TEMP: 
        mainMenu.SetActive(true);
        playMenu.SetActive(false);
        optionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        changelogMenu.SetActive(false);
    }

    public void QuitGame(){

        // TODO: Pop up?
        // TODO: Animation?
        Application.Quit();
    }
    #endregion

    #region PlaySubMenu

    public void NewGameButton(){
        // TODO: Make a pop up asking if you really want to make a new game
        // TODO: Wipe old saved data
        // TODO: Make a new game

        // TEMP: Load the test level scene
        SceneManager.LoadScene(1);

    }

    public void LoadGameButton(){
        // TODO: Load the currently saved game
    }

    #endregion
}
