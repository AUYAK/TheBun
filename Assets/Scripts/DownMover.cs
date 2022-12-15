using UnityEngine;

public class DownMover : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    private Spawner spawner;
    private bool spawned;

    private void Start() {
        spawner = FindObjectOfType<Spawner>();
        speed = spawner.speed;
    }
    private void FixedUpdate() {
        transform.Translate(Vector2.down*speed*Time.fixedDeltaTime);
        speed += spawner.speedIncrease * Time.fixedDeltaTime;
        if(transform.position.y<0 && !spawned)
        {
            spawner.SpawnerWave();
            spawned = true;
        }
        if(transform.position.y<-12)
        {
            Destroy(this.gameObject);
        }
    }
}
