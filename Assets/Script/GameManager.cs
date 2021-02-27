using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public GameObject Winscreen;
    public GameObject LoseScreen;
    public bool GameStarted { get; private set; }
    public bool GameEnded { get; private set; }
    [SerializeField]private float slowmotionfactor = 0.1f;
    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform goalTransform;
    [SerializeField] private PlayerMovement ball;

    public float TotalDistance { get; private set; }
    public float distanceRemain { get; set; }

    private void Start()
    {
        StartGame();
        TotalDistance = goalTransform.position.z - startTransform.position.z;
 
    }

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
    public void StartGame()
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
        else
        {
            Invoke("WinGame", 2);
        }
        //RestartGame();
    }
    public void RestartGame()
    {
        LoseScreen.SetActive(true);
      //  SceneManager.LoadScene(1);
    }
    public void WinGame()
    {
        Winscreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        distanceRemain = Vector3.Distance(ball.transform.position, goalTransform.transform.position);

        if(distanceRemain > TotalDistance)
        {
            distanceRemain = TotalDistance;
        }

        if(ball.transform.position.z > goalTransform.transform.position.z)
        {
            distanceRemain = 0;
        }
        Debug.Log("Travelled ditance is" + distanceRemain + " total " + TotalDistance);
    }
}
