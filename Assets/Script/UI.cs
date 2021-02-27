using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void OnPressPlay()
    {
        SceneManager.LoadScene(1);
    }
}
