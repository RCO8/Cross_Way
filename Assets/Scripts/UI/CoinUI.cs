using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI textMesh;

    private void LateUpdate()
    {
        textMesh.text = $"Coin : {GameManager.Instance.Player.action.CoinScore.ToString()}";
    }
}
