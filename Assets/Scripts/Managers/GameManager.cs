using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isPlaying { get; set; } = true;


    public GameObject Player;

    public GameObject MenuUI;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Start()
    {
        isPlaying = true;

        MenuUI.SetActive(false);
    }

    public void OpenMenu(bool act)
    {
        MenuUI.SetActive(act);

        //메뉴가 열려있다면
        Time.timeScale = act ? 0f : 1f;
    }
}
