using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public bool GameStarted { get; private set; }
    public bool GameEnded { get; private set; }

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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
