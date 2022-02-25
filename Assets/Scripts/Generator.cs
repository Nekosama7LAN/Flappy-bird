using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private Obstacles[] obstacles = null;
    [SerializeField] private float spawnTime = 3f;
    [SerializeField] private float spawnRange = 2f;
    bool isGeneratorActive = false;
    int obstacleCounter = 0;
    
    public void StarGenerator()
    {
        isGeneratorActive = true;
        InvokeRepeating("PlaceObstacle", spawnTime, spawnTime);
    }
    void PlaceObstacle()
    {
        if (isGeneratorActive == false)
        {
            return;
        }
        obstacles[obstacleCounter].transform.localPosition = Vector3.up * Random.Range(-spawnRange, spawnRange);
        obstacles[obstacleCounter].isActive = true;
        obstacleCounter++;
        if (obstacleCounter >= obstacles.Length)
        {
            obstacleCounter = 0;
        }
    }
    public void StopGenerator()
    {
        isGeneratorActive = false;
        CancelInvoke();
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].isActive = false;
        }
    }
}
