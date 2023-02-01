using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    [SerializeField] GameObject[] collectSounds;
    [SerializeField] GameObject favorSound;
    
    void Collect()
    {
        collectSounds[Random.Range(0, collectSounds.Length)].GetComponent<AudioSource>().Play();
        favorSound.GetComponent<AudioSource>().Play();
    }
}
