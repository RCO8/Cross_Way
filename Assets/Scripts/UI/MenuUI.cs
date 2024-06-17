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

    public void ResumeButtonAction()    //버튼이 눌려졌을때
    {
        if (CaptionText.text.Equals(GameOverText))  //다시 시작
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else   //계속
        {
            GameManager.Instance.OpenMenu(false);
        }
    }

    public void ExitButtonAction()
    {
        //게임 종료
        Application.Quit();
    }

    //메뉴창 입력
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
