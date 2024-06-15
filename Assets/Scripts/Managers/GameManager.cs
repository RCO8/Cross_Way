using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Player;
    public GameObject MenuUI;
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

        if(MenuUI.active)
            MenuUI.SetActive(false);
    }

    public void OpenMenu(bool menu)
    {
        MenuUI.SetActive(menu);
        Time.timeScale = menu ? 0f : 1f;
    }
}
