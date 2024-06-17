using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public MenuUI MenuUI;
    public Player Player;
    public ObjectPool Pooling;

    public bool isPlaying { get; set; } = true;


    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        Pooling = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        isPlaying = true;
        Time.timeScale = 1f;

        if (MenuUI.gameObject.active)
            MenuUI.gameObject.SetActive(false);
    }

    public void OpenMenu(bool menu)
    {
        MenuUI.gameObject.SetActive(menu);
        Time.timeScale = menu ? 0f : 1f;
        Player.input.playerInput.SwitchCurrentActionMap(menu ? "Option" : "Player");
    }

    public void GameOver()
    {
        isPlaying = false;
        OpenMenu(true);
        MenuUI.GameOverPanel();
    }
}
