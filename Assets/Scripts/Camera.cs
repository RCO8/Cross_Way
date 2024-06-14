using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 camPos = new Vector3(0, Player.transform.position.y, -10f);

        transform.position = camPos;
    }
}
