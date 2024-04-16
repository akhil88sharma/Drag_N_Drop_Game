using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    public void ReplayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
