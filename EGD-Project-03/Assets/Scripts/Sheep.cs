using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField] float killHeight = -100f;
    [SerializeField] GameObject[] dieSounds, grinderSounds;
    [SerializeField] GameObject woolParticles, bloodParticles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < killHeight)
        {
            Destroy(this.gameObject);
        }
    }

    void Die()
    {
        if (Random.Range(0, 2) > 0.5)
        {
            dieSounds[Random.Range(0, dieSounds.Length)].GetComponent<AudioSource>().Play();
        }
        grinderSounds[Random.Range(0, grinderSounds.Length)].GetComponent<AudioSource>().Play();

        Instantiate(woolParticles, transform.position, Quaternion.identity);
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
    }
}
