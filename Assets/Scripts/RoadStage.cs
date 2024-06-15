using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoadStage : MonoBehaviour
{
    private GameObject treePrefab;
    private GameObject[] coinPrefab = new GameObject[3];

    private float waitingTime;

    [SerializeField]
    private Transform WayLine1, WayLine2;
    [SerializeField]
    private Transform HumanLine;

    private List<Vector2> WayLineCar = new List<Vector2>();   //생성될 차의 위치

    void Start()
    {
        treePrefab = Resources.Load<GameObject>("Prefabs/Tree");

        waitingTime = Random.Range(1.5f, 2.5f);

        coinPrefab[0] = Resources.Load<GameObject>("Prefabs/CoinBronze");
        coinPrefab[1] = Resources.Load<GameObject>("Prefabs/CoinSilver");
        coinPrefab[2] = Resources.Load<GameObject>("Prefabs/CoinGold");

        //인도 설정
        InitTree();
        InitCoin();

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

    private void Update()
    {
        DestroyRoad();
    }

    private void InitCoin()
    {
        int createCoinCount = Random.Range(1, 4);

        for (int i = 0; i < createCoinCount; i++)
        {
            Vector3 createCoinPosition = new Vector2(Random.Range(-12f, 12f), 0f);
            //이 코드를 오브젝트 풀링으로 변경
            GameObject coin = Instantiate(coinPrefab[Random.Range(0, coinPrefab.Length)], HumanLine.position + createCoinPosition, Quaternion.identity);
            coin.transform.SetParent(transform);
        }
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
            //Instantiate(carPrefab, roadLine.position + direction, Quaternion.identity);
            GameObject car = GameManager.Instance.Pooling.SpawnFromPool("Car");
            car.transform.position = roadLine.position + direction;

            car.GetComponent<Car>().SetDirection(direction.x < 0);

            waitingTime = Random.Range(1.5f, 2.5f);
            yield return new WaitForSeconds(waitingTime);
        }
    }

    private void DestroyRoad()
    {
        if(transform.position.y + 16 < GameManager.Instance.Player.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
