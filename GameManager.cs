using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;
    public GameObject retryBtn;
    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;

    public Text levelText;
    public Transform levelFront;

    private int level = 0;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("MakeCat", 0.0f, 1.0f);
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeCat()
    {
        Instantiate(normalCat);
        if (level == 1)
        {
            float p = Random.Range(0, 10);
            if(p < 2) { Instantiate(normalCat); }
        }
        else if (level >= 2)
        {
            float p = Random.Range(0, 10);
            if (p < 5) { Instantiate(normalCat); }
        }
        if (level >= 3)
        {
            Instantiate(fatCat);
        }
        if (level >= 4)
        {
            Instantiate(pirateCat);
        }
    }
    public void AddScore()
    {
        score++;
        level = score / 5;

        levelText.text = level.ToString();
        levelFront.localScale = new Vector3((score - level * 5) / 5.0f, 1.0f, 1.0f);
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
