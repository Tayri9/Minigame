using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization.Settings;
using static Game;

public class Menus : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject levelMenu;
    [SerializeField] GameObject game;
    //[SerializeField] GameObject background;

    [SerializeField] float timeIn = 1.5f;
    [SerializeField] float timeOut = 0.5f;

    int language = 0;
    int langAvailables;
    #endregion
    #region Methods
    // Start is called before the first frame update
    void Start()
    {     
        ActivarMainMenu();

        langAvailables = LocalizationSettings.AvailableLocales.Locales.Count;
        SelectCurrentLang();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectCurrentLang()
    {
        UnityEngine.Localization.Locale searcher = LocalizationSettings.AvailableLocales.Locales[language];
        while (searcher != LocalizationSettings.SelectedLocale && language < langAvailables)
        {
            language++;
            searcher = LocalizationSettings.AvailableLocales.Locales[language];
        }
    }
    void ActivarMainMenu()
    {      
        //background.SetActive(true);
        settingsMenu.SetActive(false);
        levelMenu.SetActive(false);
        game.SetActive(false);

        LeanTween.alphaCanvas(mainMenu.GetComponent<CanvasGroup>(), 0, 0);
        mainMenu.SetActive(true);
        LeanTween.alphaCanvas(mainMenu.GetComponent<CanvasGroup>(), 1, timeIn);
    }
    void ActivarSettingsMenu()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        game.SetActive(false);

        LeanTween.alphaCanvas(settingsMenu.GetComponent<CanvasGroup>(), 0, 0);
        settingsMenu.SetActive(true);
        LeanTween.alphaCanvas(settingsMenu.GetComponent<CanvasGroup>(), 1, timeIn);
    }

    void ActivarLevelMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        game.SetActive(false);

        LeanTween.alphaCanvas(levelMenu.GetComponent<CanvasGroup>(), 0, 0);
        levelMenu.SetActive(true);
        LeanTween.alphaCanvas(levelMenu.GetComponent<CanvasGroup>(), 1, timeIn);
    }

    void ActivarGameUI()
    {
        //background.SetActive(false);
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        levelMenu.SetActive(false);

        //LeanTween.alphaCanvas(game.GetComponent<CanvasGroup>(), 0, 0);
        game.SetActive(true);
        //LeanTween.alphaCanvas(game.GetComponent<CanvasGroup>(), 1, timeIn).setOnComplete(ChangeToGame);
        ChangeToGame();
    }

    void ChangeToGame()
    {
        Debug.Log("Change to game");
        Game.instance.currentState = Game.StateSelector.Countdown;
    }

    #region ButtonsMainMenu
    public void ButtonPlay()
    {        
        LeanTween.alphaCanvas(mainMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarLevelMenu); 
    }

    public void ButtonSettingsMainMenu()
    {
        LeanTween.alphaCanvas(mainMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarSettingsMenu);        
    }

    public void ButtonExit()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
    #endregion

    #region ButtonsSettings
    public void ButtonBackSettings()
    {
        LeanTween.alphaCanvas(settingsMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarMainMenu);        
    }

    public void ButtonNext() 
    {
        Debug.Log("Next Language");
        language += 1;
        if (language >= langAvailables)
        {
            language = 0;
        }
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[language];
    }

    public void ButtonPrevious()
    {
        Debug.Log("Previous Language");
        if (language <= 0)
        {
            language = langAvailables;
        }
        language -= 1;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[language];
    }
    #endregion

    #region ButtonsLevel
    public void ButtonBackLevel()
    {
        LeanTween.alphaCanvas(levelMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarMainMenu);        
    }

    public void ButtonEasy()
    {
        Game.instance.SetDificultad(1);
        LeanTween.alphaCanvas(levelMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarGameUI);
        Debug.Log("Easy");
    }

    public void ButtonMedium()
    {
        Game.instance.SetDificultad(2);
        LeanTween.alphaCanvas(levelMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarGameUI);
        Debug.Log("Medium");
    }

    public void ButtonHard()
    {
        Game.instance.SetDificultad(3);
        LeanTween.alphaCanvas(levelMenu.GetComponent<CanvasGroup>(), 0, timeOut).setOnComplete(ActivarGameUI);        
        Debug.Log("Hard");
    }
    #endregion
    #endregion
}
