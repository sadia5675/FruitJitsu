using UnityEngine;
using System.Collections;

//als Game Mangager
public class ScoreScript : MonoBehaviour {
    public int score = 0;
    public int bombCount = 0;
    public static ScoreScript Instance { get; private set; }
    public PlayerUIController myUIController;
   public ObjectSpawner spawner;

    private void Start()
    {
    }

    
    public void NewGame()
    {
        Time.timeScale = 1f;

        score = 0;
        bombCount = 0;
        spawner.enabled = true;
        spawner.actInterval = spawner.IntervalBetweenSpawn;
      
    }

     public void Explode()
    {
        Debug.Log("Exploded");
        spawner.enabled = false;
        myUIController.gameoverUIsetting();
        //StartCoroutine(ExplodeSequence());
    }

    // private IEnumerator ExplodeSequence()
    // {
    //     float elapsed = 0f;
    //     float duration = 0.5f;

    //     // Fade to white
    //     while (elapsed < duration)
    //     {
    //         float t = Mathf.Clamp01(elapsed / duration);
    //         //fadeImage.color = Color.Lerp(Color.clear, Color.white, t);

    //         Time.timeScale = 1f - t;
    //         elapsed += Time.unscaledDeltaTime;

    //         yield return null;
    //     }

    //     yield return new WaitForSecondsRealtime(1f);

    //     NewGame();

    //     elapsed = 0f;

    //     // Fade back in
    //     while (elapsed < duration)
    //     {
    //         float t = Mathf.Clamp01(elapsed / duration);
    //         //fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

    //         elapsed += Time.unscaledDeltaTime;

    //         yield return null;
    //     }
    // }


    void OnGUI()
    {
        //We display the game GUI from the playerscript
        //It would be nicer to have a seperate script dedicated to the GUI though...
        

        GUILayout.Label("Score: " + score);
    }    

}
