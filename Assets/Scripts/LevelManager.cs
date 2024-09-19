using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameManager gameManager;
    private Collider2D foundBoundingShape;
    void Start()
    {
        gameManager = GameManager.gameManager;
    }
    public void LoadThisScene(string sceneName)
    {
        if(sceneName.StartsWith("Level"))
        {
            gameManager.gameState = GameManager.GameState.Gameplay;
            gameManager.ChangeGameState();
        }
        else if(sceneName == "MainMenu")
        {
            gameManager.gameState = GameManager.GameState.MainMenu;
            gameManager.ChangeGameState();
        }
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            LoadThisScene("Level 2");
        }
        if(SceneManager.GetActiveScene().name == "Level 2")
        {
            LoadThisScene("Level 3");
        }
        if(SceneManager.GetActiveScene().name == "Level 3")
        {
            LoadThisScene("Level 1");
        }
    }
    public void LoadPrevScene()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            LoadThisScene("Level 3");
        }
        if(SceneManager.GetActiveScene().name == "Level 2")
        {
            LoadThisScene("Level 1");
        }
        if(SceneManager.GetActiveScene().name == "Level 3")
        {
            LoadThisScene("Level 2");
        }
    }
}
