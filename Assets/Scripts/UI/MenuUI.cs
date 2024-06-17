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

    [SerializeField]
    private RectTransform[] labelMenus;

    private int selectPointer = 0;

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
        if (CaptionText.text.Equals(GameOverText))  //�ٽ� ����
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else   //���
        {
            GameManager.Instance.OpenMenu(false);
        }
    }

    public void ExitButtonAction()
    {
        //���� ����
        Application.Quit();
    }

    //�޴�â �Է�
    public void OnConfirm(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            switch(selectPointer)
            {
                case 0: //Resume or Restart
                    ResumeButtonAction();
                    break;
                case 1: //exit
                    ExitButtonAction();
                    break;
            }
        }    
    }

    public void OnCursorMove(InputAction.CallbackContext context)
    {

    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            Debug.Log("Cancel");
        }
    }
}
