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

    [SerializeField] bool settingsOpenFromMainMenu = false;
    [SerializeField] bool settingsOpenFromPause = false;
    #endregion
    #region Methods
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        levelMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            pauseMenu.SetActive(true);
        }
    }

    #region ButtonsMainMenu
    public void ButtonPlay()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void ButtonSettingsMainMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
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
        settingsMenu.SetActive(false);
        if (settingsOpenFromMainMenu)
        {
            mainMenu.SetActive(true);
        } else if(settingsOpenFromPause)
        {
            pauseMenu.SetActive(true);
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
        levelMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ButtonEasy()
    {
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
        pauseMenu.SetActive(false);
    }

    public void ButtonSettingsPause()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
        settingsOpenFromMainMenu = false;
        settingsOpenFromPause = true;
    }

    public void ButtonExitPause()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    #endregion
    #endregion
}
