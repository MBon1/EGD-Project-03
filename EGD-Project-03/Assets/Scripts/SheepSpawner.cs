using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    [SerializeField] public float spawnRate = 2;
    [SerializeField] private GameObject sheepPrefab;
    [SerializeField] private Sprite[] sheepSprites;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSheep());
    }

    private IEnumerator SpawnSheep()
    {
        yield return new WaitForSeconds(spawnRate);
        GameObject sheep = Instantiate(sheepPrefab, this.transform);
        if (sheepSprites.Length > 0)
        {
            sheep.GetComponent<SpriteRenderer>().sprite = sheepSprites[Random.Range(0, sheepSprites.Length - 1)];
        }
        StartCoroutine(SpawnSheep());
    }
}
