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
        carPrefab = Resources.Load<GameObject>("Prefabs/Car");

        Vector3 carStartPos1 = new Vector2(-10, 0);

        Instantiate(carPrefab, WayLine1.transform.position + carStartPos1, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
