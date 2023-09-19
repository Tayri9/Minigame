using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Poner")]    
    [SerializeField] float timeToSpawn;    
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject foodPrefab;

    [Header("NoPoner")]
    [SerializeField] float timer = 0;
    [SerializeField] float timerToSpawn;
    [SerializeField] Vector2 position;

    // Start is called before the first frame update
    void Start()
    {
        timerToSpawn = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = ((int) timer).ToString();

        if(timer >= timerToSpawn)
        {
            timerToSpawn = timer + timeToSpawn;
            Instantiate(foodPrefab, position);
        }
    }
}
