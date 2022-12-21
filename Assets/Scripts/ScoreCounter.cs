
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;
    public int score;

    private Spawner spawner;

    private void Start() {
        spawner = FindObjectOfType<Spawner>();
    }
    public void ScoreChange() {
        int speedNum = Mathf.RoundToInt(spawner.speed*0.1f);
        score += 1;
        scoreText.text = score.ToString();
        
    }

    
}
