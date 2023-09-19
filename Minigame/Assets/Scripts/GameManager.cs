using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Poner")]
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI pointsText;

    [Header ("NoPoner")]
    [SerializeField] int points;
    [SerializeField] float timer = 20;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        slider.maxValue = timer;
        slider.minValue = 0;
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        slider.value = timer;

        if (Input.GetMouseButtonDown(0))
        {            
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Food"))
                {
                    Debug.Log("tocado");
                    points++;
                    timer += 5;
                    slider.value = timer;
                }

                if (hitInfo.collider.CompareTag("Bomb"))
                {
                    points -= 5;
                    timer -= 10;
                    slider.value = timer;
                }

                if(timer > 20)
                {
                    timer = 20;
                }

            } else
            {
                points -= 2;
                timer -= 5;
                slider.value = timer;
            }

            pointsText.text = points.ToString();
        }
    }
}

//terminar con putons negativos o si el tiempo llega a 0
