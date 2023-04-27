using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //i want to end the game when the player touch the endgame object then the game will end without any scene
        if (other.tag == "player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    // Start is called before the first frame update
}
