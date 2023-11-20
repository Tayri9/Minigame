using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Game;
using System.Threading;
using UnityEditor;

public class Game : MonoBehaviour
{
    #region Singleton
    public static Game instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }
    #endregion

    [Header("Temporizador")]
    [SerializeField] GameObject countdownCanvas;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] float timer = 4;

    [Header("Gameover")]
    [SerializeField] GameObject GameoverCanvas;
    [SerializeField] TextMeshProUGUI GameoverText;
    [SerializeField] GameObject backgroundCanvas;
    [SerializeField] GameObject mainMenuCanvas;

    [Header("Limit")]
    [SerializeField] Transform topLimit;
    [SerializeField] Transform bottomLimit;

    [Header("Fish")]
    [SerializeField] Transform fish;
    [SerializeField] float timerMultiplicator = 3f; //facil:6 - medio:3 - dificil:1
    [SerializeField] float smoothMotion = 1f; //facil:1 - medio:0.75 - dificil:0.5

    [Header("Fish - No tocar")]
    [SerializeField] float fishPosition;
    [SerializeField] float fishDestination;
    [SerializeField] float fishTimer;
    [SerializeField] float fishSpeed;

    [Header("Hook")]
    [SerializeField] Transform hook;
    [SerializeField] SpriteRenderer hookSpriteRender;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;

    [Header("Hook - No tocar")]
    [SerializeField] float hookPosition;
    [SerializeField] float hookPullVelocity;

    [Header("ProgressBar")]
    [SerializeField] Transform progressBarContainer;
    [SerializeField] float hookPower = 5f;
    [SerializeField] float hookProgressDegradationPower = 0.1f;
    [SerializeField] float hookProgress = 0.3f;
    
    public enum StateSelector
    {
        Menu,
        Playing,
        Countdown        
    }

    [Header("Estado")]
    [SerializeField]
    public StateSelector currentState = StateSelector.Menu;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
        Resize();
        GameoverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case StateSelector.Playing:
                Playing();
                break;

            case StateSelector.Countdown:
                Countdown();
                break;
        }
    }

    void Playing()
    {        
        Fish();
        Hook();
        ProgressCheck();
    }

    void Countdown()
    {
        countdownCanvas.SetActive(true);
        LeanTween.alphaCanvas(countdownCanvas.GetComponent<CanvasGroup>(), 1, 0);
        timer -= Time.deltaTime;
        countdownText.text = ((int)timer).ToString();
        if (timer < 1)
        {
            LeanTween.alphaCanvas(countdownCanvas.GetComponent<CanvasGroup>(), 0, 1);
            currentState = StateSelector.Playing;
            timer = 4;
        }
    }

    void Hook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }

        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if (hookPosition - hookSize / 2 <= 0 && hookPullVelocity < 0)
        {
            hookPullVelocity = 0;
        }

        if (hookPosition + hookSize / 2 >= 1 && hookPullVelocity > 0)
        {
            hookPullVelocity = 0;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);
        hook.position = Vector3.Lerp(bottomLimit.position, topLimit.position, hookPosition);
    }

    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplicator;

            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomLimit.position, topLimit.position, fishPosition);
    }

    void ProgressCheck()
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.y = hookProgress;
        progressBarContainer.localScale = ls;        

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if (min < fishPosition && fishPosition < max)
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPower * Time.deltaTime;
        }

        if (hookProgress <= 0f)
        {
            GameOver("Lose");
        }

        if (hookProgress >= 1f)
        {
            GameOver("Win");
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);
    }

    void Resize()
    {
        Bounds b = hookSpriteRender.bounds;
        float ySize = b.size.y;
        Vector3 ls = hook.localScale;
        float distance = Vector3.Distance(topLimit.position, bottomLimit.position);
        ls.y = (distance / ySize * hookSize);
        hook.localScale = ls;
    }

    void GameOver(string text)
    {
        backgroundCanvas.SetActive(true);
        GameoverCanvas.SetActive(true);
        GameoverText.text = text;
        currentState = StateSelector.Menu;
        ResetGame();
    }

    public void MainMenu()
    {        
        GameoverCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
        LeanTween.alphaCanvas(mainMenuCanvas.GetComponent<CanvasGroup>(), 1, 1.5f);
    }

    void ResetGame()
    {
        fish.position = Vector3.zero;
        fishPosition = 0;
        fishDestination = 0;
        fishTimer = 0;
        fishSpeed = 0;
        hook.position = Vector3.zero;
        hookPosition = 0;
        hookPullVelocity = 0;
        progressBarContainer.localScale = Vector3.one;
        hookProgress = 0.3f;        
    }

    public void SetDificultad(int dificultad)
    {
        switch (dificultad)
        {
            case 1:
                timerMultiplicator = 6f;
                smoothMotion = 1f;
                break;

            case 2:
                timerMultiplicator = 3f;
                smoothMotion = 0.75f;
                break;

            case 3:
                timerMultiplicator = 1f;
                smoothMotion = 0.5f;
                break;
        }
    }
}

/*
 [SerializeField] float timerMultiplicator = 3f; //facil:6 - medio:3 - dificil:1
 [SerializeField] float smoothMotion = 1f; //facil:1 - medio:0.75 - dificil:0.5
*/