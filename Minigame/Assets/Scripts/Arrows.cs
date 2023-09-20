using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Arrows : MonoBehaviour
{
    [SerializeField] string arrowType; //up down left right
    [SerializeField] bool canPress;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(arrowType))
        {  
            if (canPress)
            {
                GameManager.instance.ManagePoints(1, 5);
                Destroy(gameObject);
            }
            else
            {
                //GameManager.instance.ManagePoints(-1, -2);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Limit")){
            GameManager.instance.ManagePoints(-1, -2);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Area")){
            canPress = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Area")){
            canPress = false;
        }
    }
}
