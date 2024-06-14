using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private GameObject roadStage;
    private int stageIndex;

    Queue<GameObject> stageQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        roadStage = Resources.Load<GameObject>("Prefabs/RoadStage");
        stageIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CreateStage();
    }

    private void CreateStage()
    {
        if (GameManager.Instance.Player.transform.position.y > (8 * stageIndex))
        {
            Vector3 stagePos = new Vector2(0, (stageIndex+1) * 8);

            //roadStage»ý¼º
            Instantiate(roadStage, stagePos, Quaternion.identity);
            stageIndex++;
        }
    }
}
