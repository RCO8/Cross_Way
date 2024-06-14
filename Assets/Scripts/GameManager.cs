using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isPlaying { get; set; }

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    void Start()
    {
        isPlaying = true;
    }

    void Update()
    {
        
    }
}
