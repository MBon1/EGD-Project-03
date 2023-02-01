using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funnel : MonoBehaviour
{
    [SerializeField] GameObject[] collectSounds;
    [SerializeField] GameObject favorSound;
    // [SerializeField] GameObject collectParticles;
    // MenuManager mm;

    float colliderX;

    // Start is called before the first frame update
    void Start()
    {
        // mm = GameObject.Find("GameManager").GetComponent<MenuManager>();
        colliderX = this.GetComponent<BoxCollider2D>().size.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Random.Range(0, 2) > 0.5)
        {
            collectSounds[Random.Range(0, collectSounds.Length)].GetComponent<AudioSource>().Play();
        }

        favorSound.GetComponent<AudioSource>().Play();
    }
}
