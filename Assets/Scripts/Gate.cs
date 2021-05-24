using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    int currentScene;
    private void Start()
    {
         currentScene = SceneManager.GetActiveScene().buildIndex;
    }
     
    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(currentScene + 1);
            }
        }

    }

