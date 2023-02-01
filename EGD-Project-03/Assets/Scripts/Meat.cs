using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    [SerializeField] GameObject[] collectSounds;
    [SerializeField] GameObject favorSound;
    [SerializeField] GameObject collectParticles;
    [SerializeField] private Sprite[] meatSprites;
    MenuManager mm;

    void Start()
    {
        mm = GameObject.Find("GameManager").GetComponent<MenuManager>();
        gameObject.GetComponent<SpriteRenderer>().sprite = meatSprites[Random.Range(0, meatSprites.Length - 1)];
        Destroy(gameObject, 30f);
    }

    void Collect()
    {
        Instantiate(collectParticles, new Vector3(6.81f, -3f, 0f), Quaternion.identity);
        mm.MeatCollected();

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Funnel"))
        {
            Collect();
        }
    }
}
