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
    [SerializeField] GameObject[] foodPrefab;

    [Header("NoPoner")]
    [SerializeField] float timer = 0;
    [SerializeField] float timerToSpawn;
    [SerializeField] Vector2 position;
    [SerializeField] float foodToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Random.Range(0, 1);
        timerToSpawn = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Time: " + ((int) timer).ToString();

        if(timer >= timerToSpawn)
        {
            timeToSpawn = Random.Range(0, 4);
            timerToSpawn = timer + timeToSpawn;
            position = new Vector2(Random.Range(-7.9f,0.95f), Random.Range(-4.18f, 4.19f));
            foodToSpawn = Random.Range(0, foodPrefab.Length);
            Instantiate(foodPrefab[(int)foodToSpawn], position, Quaternion.identity);
        }
    }
}
