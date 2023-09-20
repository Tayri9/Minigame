using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Poner")]  
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject arrowPrefab;

    [Header("NoPoner")]
    [SerializeField] float timer = 0;
    [SerializeField] float timeToSpawn;
    [SerializeField] float timerToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Random.Range(0, 2);
        timerToSpawn = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerText.text = "Time: " + ((int) timer).ToString();

        if(timer >= timerToSpawn)
        {
            timeToSpawn = Random.Range(1, 5);
            timerToSpawn = timer + timeToSpawn;
            Instantiate(arrowPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }
}
