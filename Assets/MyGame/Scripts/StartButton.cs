using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    public TMP_Text text_;
    // Start is called before the first frame update
    private void Awake()
    {
        text_.text = "Start";
    }

    public void ClearScreen()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("Button presseed");
    }

}
