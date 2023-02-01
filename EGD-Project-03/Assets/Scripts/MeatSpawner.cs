using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSpawner : MonoBehaviour    // Use Max's implementation
{
    [SerializeField] public Vector2 spawnRange = new Vector2(2,2);
    [SerializeField] private GameObject meatPrefab;
    [SerializeField] public Vector2 speedRange = new Vector2(1, 2);
    [SerializeField] public Vector2 angleRange = new Vector2(-2, 2);

    public void SpawnMeat()
    {
        if (spawnRange.x < 0 || spawnRange.y < spawnRange.x)
        {
            return;
        }

        for (int i = 0; i < spawnRange.y; i++)
        {
            GameObject meat = Instantiate(meatPrefab, this.transform);
//            meat.transform.rotation
        }
    }
}
