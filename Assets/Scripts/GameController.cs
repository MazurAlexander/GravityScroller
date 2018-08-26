using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameController : MonoBehaviour
{

    public static GameController I;
    public GameObject platform;
    public RectTransform rect;
    public GameObject ball;
    public GameObject bckGround;
    public Text textScore;
    public Text bestScore;
    public Text gameName;
    public Button play;
    public Button exit;
    public Button getScore;
    public int platformCount;
    public int width;
    public int createCount;
    public int score=0;
    public List<PlatformContorller> platformList = new List<PlatformContorller>();
    private bool upOrDown = true;
    private bool hidemenu = false;


    public RectTransform CanvasTransform
    {

        get
        {
            return rect;
        }
        set
        {
            rect = value;
        }
    }
    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
    }

    public void InitNewPlatformUP()
    {
        for (int i = 0; i < platformCount; i++)
        {
            var platform1 = Instantiate(platform);
            var platfornTop = platform1.GetComponent<PlatformContorller>();
            WidthPlatform();
            platformList.Add(platfornTop);
            platform1.transform.SetParent(rect);
            platform1.transform.localPosition = new Vector2((-Screen.width / 2) + (i * 450) + 250, (Screen.height / 3));
        }

    }

    public void InitNewPlatformDOWN()
    {
        for (int i = 0; i < platformCount; i++)
        {
            var platform2 = Instantiate(platform);
            var platfornBottom = platform2.GetComponent<PlatformContorller>();
            WidthPlatform();
            platformList.Add(platfornBottom);
            platform2.transform.SetParent(rect);
            platform2.transform.localPosition = new Vector2((-Screen.width / 2) + (i * 450), -(Screen.height / 3));
        }
    }

    public void BallStart()
    {
        var ballstart = Instantiate(ball);
        ballstart.transform.SetParent(rect);
        ballstart.transform.localPosition = new Vector2(-Screen.width / 2 + 50, -Screen.height / 3 + 37);

    }

    public void WidthPlatform()
    {
        width = Random.Range(150, 250);
        platform.GetComponent<BoxCollider2D>().size = new Vector2(width, 25);
        platform.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 25);


    }

    private void BckGround()
    {

        bckGround.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    private void PlatformCount()
    {
        platformCount = Screen.width / 250;
        platformCount = platformCount - 2;
        createCount = platformCount;


    }

    

    private void DownlodLvl()
    {
        PlatformCount();
        InitNewPlatformUP();
        InitNewPlatformDOWN();
        BallStart();
        
    }

    public void GameOver() {
        hidemenu = true;
        upOrDown = true;
        gameName.gameObject.SetActive(hidemenu);
        play.gameObject.SetActive(hidemenu);
        exit.gameObject.SetActive(hidemenu);
        getScore.gameObject.SetActive(hidemenu);
        textScore.gameObject.SetActive(false);
        bestScore.gameObject.SetActive(hidemenu);
    }


    public void ClearCanvas()
    {
        for (int i = 0; i < platformList.Count; i++)
        {
            Destroy(platformList[i].gameObject);
        }
        platformList.Clear();
    }

    private void InitPlatformDown()
    {
        var platform2 = Instantiate(platform);
        var platfornBottom = platform2.GetComponent<PlatformContorller>();
        WidthPlatform();
        platformList.Add(platfornBottom);
        platform2.transform.SetParent(rect);
        platform2.transform.localPosition = new Vector2((-Screen.width / 2) + (platformCount * 450), -(Screen.height / 3));
    }

    private void InitPlatformUp()
    {
        var platform1 = Instantiate(platform);
        var platfornTop = platform1.GetComponent<PlatformContorller>();
        WidthPlatform();
        platformList.Add(platfornTop);
        platform1.transform.SetParent(rect);
        platform1.transform.localPosition = new Vector2((-Screen.width / 2) + (platformCount * 450), (Screen.height / 3));
    }

    public void Score() {
        
       
        textScore.text = "Score : " + score;
    }

    public void CheckScore() {
        
        int bscore;
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bscore = PlayerPrefs.GetInt("BestScore");
            if (bscore < score)
            {
                PlayerPrefs.SetInt("BestScore", score);
                PlayerPrefs.Save();
            }
        }
    }

    private void BestScore()
    {
        int bscore=0;
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bscore = PlayerPrefs.GetInt("BestScore");
            bestScore.text = "Best Score : " + bscore;
        }
    }
    private void HideMenu() {
        hidemenu = false;
        gameName.gameObject.SetActive(hidemenu);
        play.gameObject.SetActive(hidemenu);
        exit.gameObject.SetActive(hidemenu);
        getScore.gameObject.SetActive(hidemenu);
        textScore.gameObject.SetActive(true);
        bestScore.gameObject.SetActive(hidemenu);

    }
    public void GetScore() {
        bestScore.gameObject.SetActive(true);
        BestScore();
    }

    public void Exit() {
        Application.Quit();

    }
    public void GameStart() {
        HideMenu();
        DownlodLvl();
        Score();
        

    }
    private void FirstStart()
    {
        BckGround();
        textScore.gameObject.SetActive(false);
        if (!PlayerPrefs.HasKey("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", 0);
            PlayerPrefs.Save();
        }
        BestScore();
    }

    private void Update()
    {
        if (createCount != platformCount)
        {
            if (upOrDown)
            {
                InitPlatformDown();
                upOrDown = false;
            }
            else
            {
                InitPlatformUp();
                upOrDown = true;
            }

        }
        createCount = platformCount;
    }



    void Start()
    {
        FirstStart();

    }

}
