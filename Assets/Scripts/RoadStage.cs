using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadStage : MonoBehaviour
{
    private GameObject carPrefab;
    [SerializeField]
    private Sprite Car1, Car2;

    [SerializeField]
    private GameObject WayLine1, WayLine2;

    void Start()
    {
        carPrefab = Resources.Load<GameObject>("Car");
    }

    void Update()
    {
        
    }
}
