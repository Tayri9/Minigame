using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Game;
using System.Threading;

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
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float timer = 4;

    public enum StateSelector
    {
        Menu,
        Playing,
        Countdown        
    }

    [SerializeField]
    public StateSelector currentState = StateSelector.Menu;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("Jugando");
    }

    void Countdown()
    {
        timer -= Time.deltaTime;
        timeText.text = ((int)timer).ToString();
        if (timer < 0)
        {
            currentState = StateSelector.Playing;
            timer = 4;
        }
    }
}
