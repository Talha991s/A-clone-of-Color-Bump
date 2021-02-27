using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public bool GameStarted { get; private set; }
    public bool GameEnded { get; private set; }
    [SerializeField]private float slowmotionfactor = 0.1f;

    private void Awake()
    {
        if(singleton ==null)
        {
            singleton = this;
        }
        else if(singleton != this)
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
    }

    // Start is called before the first frame update
    public void Start()
    {
        GameStarted = true;
        Debug.Log("Game Started");
    }

    public void EndGame(bool win)
    {
        GameEnded = true;
        Debug.Log("Game Ended");

        if(!win)
        {
            Invoke("RestartGame", 2 * slowmotionfactor);
            Time.timeScale = slowmotionfactor;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        //RestartGame();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
