using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadStage : MonoBehaviour
{
    private GameObject carPrefab;
    private float waitingTime;

    [SerializeField]
    private GameObject WayLine1, WayLine2;

    void Start()
    {
        carPrefab = Resources.Load<GameObject>("Prefabs/Car");

        waitingTime = Random.Range(1.5f, 2.5f);
        InvokeRepeating("InitCar", 0, waitingTime);
    }

    private void InitCar()
    {
        //WayLin2
        carPrefab.GetComponent<Car>().SetDirection(false);
        Instantiate(carPrefab, WayLine2.transform.position + new Vector3(10, 1.25f), Quaternion.identity);
        Instantiate(carPrefab, WayLine2.transform.position + new Vector3(10, -0.4f), Quaternion.identity);

        //WayLine1
        carPrefab.GetComponent<Car>().SetDirection(true);
        Instantiate(carPrefab, WayLine1.transform.position + new Vector3(-10, 1.25f), Quaternion.identity);
        Instantiate(carPrefab, WayLine1.transform.position + new Vector3(-10, -0.4f), Quaternion.identity);

        waitingTime = Random.Range(1.5f, 2.5f);
    }

    private void DestroyRoad()
    {
        if(Vector2.Distance(transform.position, GameManager.Instance.Player.transform.position) > 16)
        {
            Destroy(gameObject);
        }
    }
}
