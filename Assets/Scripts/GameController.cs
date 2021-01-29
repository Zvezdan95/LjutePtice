using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] string _firstLevelName;

    public void GameStart()
    {
        SceneManager.LoadScene(_firstLevelName);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
