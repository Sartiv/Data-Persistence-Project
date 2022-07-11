using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI textNickname;
    public TextMeshProUGUI bestScore;
    public TMP_InputField typeNickname;

    private void Start()
    {
        bestScore.text = "Best Score: " + PersistData.Instance.bestNickname + " " + PersistData.Instance.bestScore;
    }

    public void GoToMain()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void ReadInputNickname(string nickname)
    {
        
        Debug.Log(nickname);
        textNickname.text = "Your nickname is " + nickname;
        PersistData.Instance.nickname = nickname;
    }

}

