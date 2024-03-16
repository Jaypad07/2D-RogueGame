using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public int level;
    public int baseSeed;

    private int prevRoomPlayerHealth;
    private int prevRoomPlayerCoins;

    private Player player;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        level = 1;
        baseSeed = PlayerPrefs.GetInt("Seed");
        Random.InitState(baseSeed);
        Generation.Instance.Generate();
        UI.instance.UpdateLevelText(level);

        player = FindObjectOfType<Player>();
        
        // My Personal fix to update stats and level when player dies. MiniMap still is not updated and level increases to next level.
        player.curHp = player.maxHp;
        player.coins = player.coins = 0;
        UI.instance.UpdateHealth(player.curHp);
        UI.instance.UpdateCoinText(player.coins);
        UI.instance.UpdateLevelText(level);
        // My Personal fix to update stats and level when player dies. MiniMap still is not updated and level increases to next level.

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void GoToNextLevel()
    {
        prevRoomPlayerHealth = player.curHp;
        prevRoomPlayerCoins = player.coins;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Game")
        {
            Destroy(gameObject);
            return;
        }

        player = FindObjectOfType<Player>();
        level++;
        baseSeed++;
        
        Generation.Instance.Generate();
        player.curHp = prevRoomPlayerHealth;
        player.coins = prevRoomPlayerCoins;
        
        UI.instance.UpdateHealth(prevRoomPlayerHealth);
        UI.instance.UpdateCoinText(prevRoomPlayerCoins);
        UI.instance.UpdateLevelText(level);
    }
}