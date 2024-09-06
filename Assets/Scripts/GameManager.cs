using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField]
    private UIManager uIManager;
    public enum GameState{MainMenu, Gameplay}
    public GameState gameState;
    public float health;
    public int str;
    public int dex;
    public int con;
    public int mind; //INT in game
    public int wis;
    public int cha;
    public int exp;
    public int score;
    void Awake()
    {
        if(gameManager != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            gameManager = this;
        }
    }

    void Start()
    {
        gameState = GameState.MainMenu;
    }

    public void ChangeGameState()
    {
        switch(gameState)
        {
            case GameState.MainMenu: MainMenu(); break;
            case GameState.Gameplay: Gameplay(); break;
        }
    }

    void MainMenu()
    {
        uIManager.SetActiveUI("MainMenu");
    }

    void Gameplay()
    {
        uIManager.SetActiveUI("StatsMenu");
    }


    public void Save()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            
            data.health = health;
            data.str = str;
            data.dex = dex;
            data.con = con;
            data.mind = mind;
            data.wis = wis;
            data.cha = cha;
            data.exp = exp;
            data.score = score;

            bf.Serialize(file, data);
            file.Close();
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

            PlayerData data = new PlayerData();
            data.health = health;
            data.str = str;
            data.dex = dex;
            data.con = con;
            data.mind = mind;
            data.wis = wis;
            data.cha = cha;
            data.exp = exp;
            data.score = score;

            bf.Serialize(file, data);
            file.Close();   
        }
    }

    public bool CheckforSave()
    {
        bool doseSaveExisit = File.Exists(Application.persistentDataPath + "/playerInfo.dat");
        return doseSaveExisit;
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            str = data.str;
            dex = data.dex;
            con = data.con;
            mind = data.mind;
            wis = data.wis;
            cha = data.cha;
            exp = data.exp;
            score = data.score;
        }
    }
}

[Serializable]
class PlayerData
{
    public float health;
    public int str;
    public int dex;
    public int con;
    public int mind;
    public int wis;
    public int cha;
    public int exp;
    public int score;
}
