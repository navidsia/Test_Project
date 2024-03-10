using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float timeStep;
    [SerializeField] GameObject pipePrefab;
    [SerializeField] float maxY, minY, xPos;

    float timeTemp;

    bool isPlaying;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if(isPlaying==false)
            return;
        timeTemp += Time.deltaTime;
        if (timeTemp >= timeStep)
        {
            SpawnPipe();
            timeTemp = 0;
        }
    }
    void SpawnPipe()
    {
        Vector2 spawnPos=new Vector2 (xPos,Random.Range(minY,maxY));
        GameObject pipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }

    public void StartSpawning()
    {
        isPlaying= true;
    }
}
