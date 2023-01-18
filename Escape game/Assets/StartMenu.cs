using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMeny : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
