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
    [SerializeField]
    private RectTransform Cursor;

    private int selectPointer = 0;

    private string GameOverText = "GAME OVER";

    private void Start()
    {
        Cursor.position = labelMenus[0].position;
        Cursor.Translate(-100, -150, 0);
    }

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
        if (context.phase == InputActionPhase.Started)
        {
            int cursor = (int)context.ReadValue<float>();
            selectPointer += cursor;
        }

        if(selectPointer > labelMenus.Length)
            selectPointer = 0;
        else if(selectPointer < 0)
            selectPointer = labelMenus.Length - 1;

        Cursor.position = labelMenus[selectPointer].position;
        Cursor.Translate(0, -150, 0);
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            Debug.Log("Cancel");
        }
    }
}
