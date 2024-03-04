using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
//als Game Mangager
public class ScoreScript : MonoBehaviour {
    public int score = 0;
    public bool showScoreLabel = false;
    public int maxScore = 0;
    public int bombCount = 0;
    public static ScoreScript Instance { get; private set; }
    public PlayerUIController myUIController;
    public ObjectSpawner spawner;
    public Canvas mainCanvas;
    public TextMeshProUGUI scoreText;


    public Image []hearts;

    private void Update()
    {
        if(showScoreLabel){
            mainCanvas.enabled=true;
            scoreText.SetText("Score: " + score);

        } else {
            mainCanvas.enabled=false;
            scoreText.SetText("");
        }
    }

    public void updateHealth(){
        
        if (bombCount >= hearts.Length)
        {
            bombCount = 0;
        }

        hearts[bombCount].color=Color.gray;

    }

    public void resetHealth()
    {
        foreach (Image h in hearts)
        {
            h.color = Color.white;
        }
    }


    public void NewGame()
    {
        Time.timeScale = 1f;

        score = 0;
        bombCount = 0;
        spawner.enabled = true;

        spawner.actInterval = spawner.intervalBetweenSpawn;
        Debug.Log("Play-ScoreScript");
        showScoreLabel=true;
    }

     public void Explode()
    {
        Debug.Log("Exploded");
        spawner.enabled = false;
        if (maxScore < score) {
            maxScore = score;
        }
        myUIController.gameoverUIsetting();
        showScoreLabel=false;
       
    }



}
