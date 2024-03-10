using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score;

    [SerializeField] Player player;
    [SerializeField] PipeSpawner spawner;

    bool isPlaying;
    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && isPlaying == false)
        {
            isPlaying = true;
            player.StartPlaying();
            spawner.StartSpawning();
        }
    }

    public void AddScore(int amount)
    {
        Score += amount;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
