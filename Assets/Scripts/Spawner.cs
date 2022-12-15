using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] blockLines;
    public float speed;
    public float speedIncrease;

    private void Update() {
        speed += speedIncrease*Time.deltaTime;
    }
    public void SpawnerWave()
    {
        int rand = Random.Range(0,blockLines.Length);
        Instantiate(blockLines[rand],transform.position,Quaternion.identity);
    }
}
