using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderBottom : MonoBehaviour
{
    [SerializeField] GameObject[] dieSounds, grinderSounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sheep"))
        {
            if (Random.Range(0, 2) > 0.5)
            {
                dieSounds[Random.Range(0, dieSounds.Length)].GetComponent<AudioSource>().Play();
            }
            //dieSounds[Random.Range(0, dieSounds.Length)].GetComponent<AudioSource>().Play();
            grinderSounds[Random.Range(0, grinderSounds.Length)].GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }

        /*if (collision.gameObject.layer == LayerMask.NameToLayer("Dead Sheep"))
        {
            *//*dieSounds[Random.Range(0, dieSounds.Length - 1)].GetComponent<AudioSource>().Play();
            grinderSounds[Random.Range(0, grinderSounds.Length)].GetComponent<AudioSource>().Play();*//*
            Destroy(collision.gameObject);
        }*/
    }
}
