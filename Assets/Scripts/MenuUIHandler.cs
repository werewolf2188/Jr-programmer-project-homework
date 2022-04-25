using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField textName;
    [SerializeField] TMP_Text ScoreText;

    void Awake()
    {
       
        textName.text = DataManager.Instance.GetName();
        ScoreText.text = $"Best Score : {DataManager.Instance.GetHighScore()}";
    }
        // Start is called before the first frame update
    public void StartNew()
    {
        DataManager.Instance.SetName(textName.text);
        DataManager.Instance.SaveUserInfo();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveUserInfo();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
