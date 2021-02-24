using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
     // There is no actual pausing of this game yet -- 
     public GameObject EntireGame;
     public GameObject GameViewBorder;
     public GameObject PausedPanel;
     public bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
       GetPauseReferences();
    }

    // Update is called once per frame
    void Update()
    {
        PauseInput();
        PauseGame();
    }

    public void PauseGame()
    {
        if (isGamePaused == true){
            // Pause the Game
            PausedPanel.SetActive(true);
            GameViewBorder.SetActive(false);
            AudioListener.pause = true;
            Time.timeScale = 0;
        }
        else if (isGamePaused == false){
            PausedPanel.SetActive(false);
            GameViewBorder.SetActive(true);
            AudioListener.pause = false;
            Time.timeScale = 1;
            
        }
        else{
            // ELSE
        }
    }

    // Object References for PauseManager
    private void GetPauseReferences(){
        PausedPanel = GameObject.FindGameObjectWithTag("PausePanel");
        EntireGame = GameObject.FindGameObjectWithTag("EntireGame");
        GameViewBorder = GameObject.FindGameObjectWithTag("GameSpace");
    }

    private void PauseInput(){
        if (Input.GetKeyDown(KeyCode.P)){
            isGamePaused = !isGamePaused;
        }
    }
}
