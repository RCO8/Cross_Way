using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI textCoinMesh;

    private void LateUpdate()
    {
        textCoinMesh.text = $"Coin : {GameManager.Instance.Player.action.CoinScore.ToString()}";
    }
}
