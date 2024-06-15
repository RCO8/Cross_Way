using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDistanceMesh;

    private float playerDistance;

    private void Start()
    {
        playerDistance = GameManager.Instance.Player.action.DistanceScore;
    }

    void Update()
    {
        playerDistance = GameManager.Instance.Player.action.DistanceScore;
        if (playerDistance > 0f)
            textDistanceMesh.text = $"{playerDistance.ToString("N2")} m";
    }
}
