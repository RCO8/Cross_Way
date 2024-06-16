using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI CaptionText;
    [SerializeField]
    private TextMeshProUGUI ResumeButtonPanel;

    private string GameOverText = "GAME OVER";

    public void GameOverPanel()
    {
        CaptionText.text = GameOverText;
        ResumeButtonText();
    }

    private void ResumeButtonText()
    {
        if (CaptionText.text.Equals(GameOverText))
            ResumeButtonPanel.text = "RESTART";
        else
            ResumeButtonPanel.text = "RESUME";
    }

    public void ResumeButtonAction()    //��ư�� ����������
    {
        if (CaptionText.text.Equals(GameOverText))
        {
            //�ٽ� ����
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            //���
            GameManager.Instance.OpenMenu(false);
        }
    }

    public void ExitButtonAction()
    {
        //���� ����
    }
}
