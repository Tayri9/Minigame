using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Menus : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject pauseMenu;

    [SerializeField] float timeIn = 1.5f;
    [SerializeField] float timeOut = 0.5f;

    [SerializeField] bool settingsOpenFromMainMenu = false;
    [SerializeField] bool settingsOpenFromPause = false;
    [SerializeField] bool canPause = false;
    #endregion
    #region Methods
    // Start is called before the first frame update
    void Start()
    {        
        settingsMenu.SetActive(false);
        levelMenu.SetActive(false);
        pauseMenu.SetActive(false);
        ActivarMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPause)
        {
            if (Input.GetKeyDown("p"))
            {
                pauseMenu.SetActive(true);
            }
        }        
    }
    void ActivarMainMenu()
    {        
        settingsMenu.SetActive(false);
        levelMenu.SetActive(false);
        pauseMenu.SetActive(false);

        LeanTween.alphaCanvas(mainMenu.GetComponent<CanvasGroup>(), 0, 0);
        mainMenu.SetActive(true);
        LeanTween.alphaCanvas(mainMenu.GetComponent<CanvasGroup>(), 1, timeIn);
    }
    void ActivarSettingsMenu()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        pauseMenu.SetActive(false);

        LeanTween.alphaCanvas(settingsMenu.GetComponent<CanvasGroup>(), 0, 0);
        settingsMenu.SetActive(true);
        LeanTween.alphaCanvas(settingsMenu.GetComponent<CanvasGroup>(), 1, timeIn);
    }

    void ActivarLevelMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(false);

        LeanTween.alphaCanvas(levelMenu.GetComponent<CanvasGroup>(), 0, 0);
        levelMenu.SetActive(true);
        LeanTween.alphaCanvas(levelMenu.GetComponent<CanvasGroup>(), 1, timeIn);
    }
    void ActivarPauseMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        levelMenu.SetActive(false);

        LeanTween.alphaCanvas(pauseMenu.GetComponent<CanvasGroup>(), 0, 0);
        pauseMenu.SetActive(true);
        LeanTween.alphaCanvas(pauseMenu.GetComponent<CanvasGroup>(), 1, timeIn);
    }

    #region ButtonsMainMenu
    public void ButtonPlay()
    {        
        LeanTween.alphaCanvas(mainMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarLevelMenu); 
    }

    public void ButtonSettingsMainMenu()
    {
        LeanTween.alphaCanvas(mainMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarSettingsMenu);
        //mainMenu.SetActive(false);
        //settingsMenu.SetActive(true);
        settingsOpenFromMainMenu = true;
        settingsOpenFromPause = false;
    }

    public void ButtonExit()
    {
        Debug.Log("Salir");
    }
    #endregion

    #region ButtonsSettings
    public void ButtonBackSettings()
    {        
        //settingsMenu.SetActive(false);
        if (settingsOpenFromMainMenu)
        {
            LeanTween.alphaCanvas(settingsMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarMainMenu);
            //mainMenu.SetActive(true);
        } else if(settingsOpenFromPause)
        {
            LeanTween.alphaCanvas(settingsMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarPauseMenu);
            //pauseMenu.SetActive(true);
        }
    }

    public void ButtonNext() 
    {
        Debug.Log("Next Language");
    }

    public void ButtonPrevious()
    {
        Debug.Log("Previous Language");
    }

    //parte de sonido
    #endregion

    #region ButtonsLevel
    public void ButtonBackLevel()
    {
        LeanTween.alphaCanvas(levelMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarMainMenu);
        //levelMenu.SetActive(false);
        //mainMenu.SetActive(true);
    }

    public void ButtonEasy()
    {
        //LeanTween.alphaCanvas(levelMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarGameUI);
        Debug.Log("Easy");
    }

    public void ButtonMedium()
    {
        Debug.Log("Medium");
    }

    public void ButtonHard()
    {
        Debug.Log("Hard");
    }
    #endregion

    #region ButtonsPause
    public void ButtonContinue()
    {
        LeanTween.alphaCanvas(pauseMenu.GetComponent<CanvasGroup>(), 0, timeOut)/*.setOnComplete(ActivarGameUI)*/;
        //pauseMenu.SetActive(false);
    }

    public void ButtonSettingsPause()
    {
        LeanTween.alphaCanvas(pauseMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarSettingsMenu);
        //pauseMenu.SetActive(false);
        //settingsMenu.SetActive(true);
        settingsOpenFromMainMenu = false;
        settingsOpenFromPause = true;
    }

    public void ButtonExitPause()
    {
        LeanTween.alphaCanvas(pauseMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarMainMenu);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    #endregion
    #endregion
}
