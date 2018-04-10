using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

    public Text scoreText;
    public Text restartText;

    public Text gameOverText;

    private int score;
	private bool gameOver;
	private bool restart;




	void Start() {
        gameOver = false;
        restart = false;
        StartCoroutine(SpawnWaves());
   
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
             UpdateScore();
    
        
       

    }


    void Update()

    {

        if (restart)

        {

            if (Input.GetKeyDown (KeyCode.R))

            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }

        }

    }





    IEnumerator SpawnWaves() {
		yield return new WaitForSeconds(startWait);
		while(!restart) {
			for (int i = 0; i < hazardCount; ++i) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		
		}
	}

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	public void GameOver() {
		gameOver = true;
		gameOverText.text = "Game Over";
	}
}
