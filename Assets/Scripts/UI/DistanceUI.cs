using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDistanceMesh;

    void LateUpdate()
    {
        float playerDiastance = GameManager.Instance.Player.transform.position.y;

        if(playerDiastance > 0f)
            textDistanceMesh.text = $"{playerDiastance.ToString("N2")} m";
    }
}
