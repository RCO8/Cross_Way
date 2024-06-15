using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Player;
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
    }
}
