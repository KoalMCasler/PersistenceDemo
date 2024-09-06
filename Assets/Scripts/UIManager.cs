using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    [Header("Object Referances")]
    public GameObject mainMenu;
    public GameObject loadMenu;
    public GameObject statsMenu;
    public Button loadButton;
    [Header("Stats Text Objects")]
    public TextMeshProUGUI healthUI;
    public TextMeshProUGUI StrUI;
    public TextMeshProUGUI DexUI;
    public TextMeshProUGUI ConUI;
    public TextMeshProUGUI IntUI;
    public TextMeshProUGUI WisUI;
    public TextMeshProUGUI ChaUI;
    public TextMeshProUGUI ExpUI;
    public TextMeshProUGUI ScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.gameManager;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameState == GameManager.GameState.Gameplay)
        {
            UpdateUIStats();
        }
        loadButton.interactable = gameManager.CheckforSave();
    }

    public void QuitGame()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    void UpdateUIStats()
    {
        healthUI.text = string.Format("Health = {0}", gameManager.health);
        StrUI.text = string.Format("STR = {0}", gameManager.str);
        DexUI.text = string.Format("DEX = {0}", gameManager.dex);
        ConUI.text = string.Format("CON = {0}", gameManager.con);
        IntUI.text = string.Format("INT = {0}", gameManager.mind);
        WisUI.text = string.Format("WIS = {0}", gameManager.wis);
        ChaUI.text = string.Format("CHA = {0}", gameManager.cha);
        ExpUI.text = string.Format("EXP = {0}", gameManager.exp);
        ScoreUI.text = string.Format("Score = {0}", gameManager.score);
    }

    public void SetActiveUI(string targetUI)
    {
        if(targetUI == "MainMenu")
        {
            loadMenu.SetActive(false);
            statsMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        if(targetUI == "LoadMenu")
        {
            statsMenu.SetActive(false);
            mainMenu.SetActive(false);
            loadMenu.SetActive(true);
        }
        if(targetUI == "StatsMenu")
        {
            loadMenu.SetActive(false);
            mainMenu.SetActive(false);
            statsMenu.SetActive(true);
        }
    }

    public void IncreaseStat(string targetStat)
    {
        if(targetStat == "health")
        {
            if(gameManager.health < 100)
            {
                gameManager.health += 10;
            }
        }
        if(targetStat == "str")
        {
            if(gameManager.str < 20)
            {
                gameManager.str += 1;
            }
        }
        if(targetStat == "dex")
        {
            if(gameManager.dex < 20)
            {
                gameManager.dex += 1;
            }
        }
        if(targetStat == "con")
        {
            if(gameManager.con < 20)
            {
                gameManager.con += 1;
            }
        }
        if(targetStat == "int")
        {
            if(gameManager.mind < 20)
            {
                gameManager.mind += 1;
            }
        }
        if(targetStat == "wis")
        {
            if(gameManager.wis < 20)
            {
                gameManager.wis += 1;
            }
        }
        if(targetStat == "cha")
        {
            if(gameManager.cha < 20)
            {
                gameManager.cha += 1;
            }
        }
        if(targetStat == "exp")
        {
            gameManager.exp += 250;
        }
        if(targetStat == "score")
        {
            gameManager.score += 150;
        }
    }

    public void DecreaseStat(string targetStat)
    {
        if(targetStat == "health")
        {
            if(gameManager.health > 0)
            {
                gameManager.health -= 10;
                if(gameManager.health < 0)
                {
                    gameManager.health = 0;
                }
            }
        }
        if(targetStat == "str")
        {
            if(gameManager.str > 1)
            {
                gameManager.str -= 1;
            }
        }
        if(targetStat == "dex")
        {
            if(gameManager.dex > 1)
            {
                gameManager.dex -= 1;
            }
        }
        if(targetStat == "con")
        {
            if(gameManager.con > 1)
            {
                gameManager.con -= 1;
            }
        }
        if(targetStat == "int")
        {
            if(gameManager.mind > 1)
            {
                gameManager.mind -= 1;
            }
        }
        if(targetStat == "wis")
        {
            if(gameManager.wis > 1)
            {
                gameManager.wis -= 1;
            }
        }
        if(targetStat == "cha")
        {
            if(gameManager.cha > 1)
            {
                gameManager.cha -= 1;
            }
        }
        if(targetStat == "exp")
        {
            if(gameManager.exp > 0)
            {
                gameManager.exp -= 200;
                if(gameManager.exp < 0)
                {
                    gameManager.exp = 0;
                }
            }
        }
        if(targetStat == "score")
        {
            gameManager.score -= 150;
        }
    }
}
