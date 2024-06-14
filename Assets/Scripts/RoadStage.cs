using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadStage : MonoBehaviour
{
    private GameObject carPrefab;

    [SerializeField]
    private GameObject WayLine1, WayLine2;

    void Start()
    {
        carPrefab = Resources.Load<GameObject>("Prefabs/Car");

        //WayLin2
        carPrefab.GetComponent<Car>().SetDirection(false);
        Instantiate(carPrefab, WayLine2.transform.position + new Vector3(10, 1.25f), Quaternion.identity);
        Instantiate(carPrefab, WayLine2.transform.position + new Vector3(10, -0.4f), Quaternion.identity);

        //WayLine1
        carPrefab.GetComponent<Car>().SetDirection(true);
        Instantiate(carPrefab, WayLine1.transform.position + new Vector3(-10, 1.25f), Quaternion.identity);
        Instantiate(carPrefab, WayLine1.transform.position + new Vector3(-10, -0.4f), Quaternion.identity);

    }

    void Update()
    {
        
    }
}
