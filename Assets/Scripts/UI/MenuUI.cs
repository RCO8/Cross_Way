using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CaptionText;

    private void Start()
    {

    }

    public void GameOverPanel()
    {
        CaptionText.text = "Game Over";
    }
}
