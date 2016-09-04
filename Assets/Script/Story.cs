using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour {


    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
