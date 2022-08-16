using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameResult;
    [SerializeField] private TextMeshProUGUI pointsText;


    public static GameController Instance;

    public static  int Points { get; private set; }
    public static bool GameStarted { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        SetPoints(0);
        gameResult.text = "";
        GameStarted = true;

        Field.Instance.GenerateField();
    }

    public void Win()
    {
        GameStarted = false;
        gameResult.text = "WIN";
    }

    public void Lose()
    {
        GameStarted = false;
        gameResult.text = "LOSE";

    }

    public void AddPoints(int points)
    {
        SetPoints(Points + points);
    }

    private void SetPoints(int points)
    {
        Points = points;
        pointsText.text = Points.ToString();
    }

}
