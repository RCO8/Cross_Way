using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadStage : MonoBehaviour
{
    private GameObject carPrefab;
    private float waitingTime;

    [SerializeField]
    private GameObject WayLine1, WayLine2;

    private List<Vector2> WayLineCar = new List<Vector2>();   //생성될 차의 위치

    void Start()
    {
        carPrefab = Resources.Load<GameObject>("Prefabs/Car");

        waitingTime = Random.Range(1.5f, 2.5f);

        WayLineCar.Add(new Vector2(-10, 1.25f));
        WayLineCar.Add(new Vector2(-10, -0.4f));
        WayLineCar.Add(new Vector2(10, 1.25f));
        WayLineCar.Add(new Vector2(10, -0.4f));

        StartCoroutine(InitOneCar(WayLine1.transform, WayLineCar[0]));
        StartCoroutine(InitOneCar(WayLine1.transform, WayLineCar[1]));
        StartCoroutine(InitOneCar(WayLine2.transform, WayLineCar[2]));
        StartCoroutine(InitOneCar(WayLine2.transform, WayLineCar[3]));
    }


    IEnumerator InitOneCar(Transform roadLine, Vector3 direction)
    {
        while (GameManager.Instance.isPlaying)
        {
            Debug.Log("코루틴");
            if(direction.x < 0)
                carPrefab.GetComponent<Car>().SetDirection(true);
            else
                carPrefab.GetComponent<Car>().SetDirection(false);
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
