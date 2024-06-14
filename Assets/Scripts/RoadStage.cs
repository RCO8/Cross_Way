using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoadStage : MonoBehaviour
{
    private GameObject carPrefab;
    private GameObject treePrefab;

    private float waitingTime;

    [SerializeField]
    private Transform WayLine1, WayLine2;
    [SerializeField]
    private Transform HumanLine;

    private List<Vector2> WayLineCar = new List<Vector2>();   //생성될 차의 위치

    void Start()
    {
        carPrefab = Resources.Load<GameObject>("Prefabs/Car");
        treePrefab = Resources.Load<GameObject>("Prefabs/Tree");

        waitingTime = Random.Range(1.5f, 2.5f);

        //인도 설정
        InitTree();

        //차선 설정
        WayLineCar.Add(new Vector2(-10, 1.25f));
        WayLineCar.Add(new Vector2(-10, -0.4f));
        WayLineCar.Add(new Vector2(10, 1.25f));
        WayLineCar.Add(new Vector2(10, -0.4f));

        StartCoroutine(InitCar(WayLine1, WayLineCar[0]));
        StartCoroutine(InitCar(WayLine1, WayLineCar[1]));
        StartCoroutine(InitCar(WayLine2, WayLineCar[2]));
        StartCoroutine(InitCar(WayLine2, WayLineCar[3]));
    }

    private void InitTree()
    {
        int treeCount = Random.Range(2, 5);

        for (int i = 0; i < treeCount; i++)
        {
            Vector3 createTreePosition = new Vector2(Random.Range(-12f, 12f), -1f);
            Instantiate(treePrefab, HumanLine.position + createTreePosition, Quaternion.identity, HumanLine);
        }
    }

    IEnumerator InitCar(Transform roadLine, Vector3 direction)
    {
        while (GameManager.Instance.isPlaying)
        {
            carPrefab.GetComponent<Car>().SetDirection(direction.x < 0);
            Instantiate(carPrefab, roadLine.position + direction, Quaternion.identity);

            waitingTime = Random.Range(1.5f, 2.5f);
            yield return new WaitForSeconds(waitingTime);
        }
    }

    private void DestroyRoad()
    {
        if(Vector2.Distance(transform.position, GameManager.Instance.Player.transform.position) > 16)
        {
            Destroy(gameObject);
        }
    }
}
