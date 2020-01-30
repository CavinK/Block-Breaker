using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) // define what happens when it's on trigger
    {
        SceneManager.LoadScene("Game Over"); // load the scene named "Game Over"
    }
}
