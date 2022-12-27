using UnityEngine;

public class DownMover : MonoBehaviour
{
    private float speed;
    private Spawner spawner;

    private ScoreCounter score;
    private bool spawned;

    private void Start() {
        score = FindObjectOfType<ScoreCounter>();
        spawner = FindObjectOfType<Spawner>();
        speed = spawner.speed;
    }
    private void FixedUpdate() {
        transform.Translate(Vector2.down*spawner.speed*Time.fixedDeltaTime);
        speed += spawner.speedIncrease * Time.fixedDeltaTime;
        if(transform.position.y<0 && !spawned)
        {
            spawner.SpawnerWave();
            spawned = true;
        }
        if(transform.position.y<=-21.5)
        {
            score.ScoreChange();
            Destroy(this.gameObject);
        }
    }
}
