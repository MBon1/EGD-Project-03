using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    [SerializeField] float killHeight = -100f;
    [SerializeField] GameObject[] dieSounds, grinderSounds;
    [SerializeField] GameObject woolParticles, bloodParticles;
    [SerializeField] GameObject meatPref;
    MenuManager mm;

    private float meatForce = 300f;

    public bool taggedToDie = false;

    // Start is called before the first frame update
    void Start()
    {
        mm = GameObject.Find("GameManager").GetComponent<MenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < killHeight)
        {
            Destroy(this.gameObject);
        }
    }



    public void Die()
    {
        if (taggedToDie)
        {
            return;
        }
        taggedToDie = true;

        if (Random.Range(0, 2) > 0.5)
        {
            // dieSounds[Random.Range(0, dieSounds.Length)].GetComponent<AudioSource>().Play();
        }
        // grinderSounds[Random.Range(0, grinderSounds.Length)].GetComponent<AudioSource>().Play();

        Instantiate(woolParticles, transform.position, Quaternion.identity);
        Instantiate(bloodParticles, transform.position, Quaternion.identity);
        for (int i = 0; i < mm.GetMeatRate(); i++)
        {
            GameObject meatIns = Instantiate(meatPref, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            meatIns.GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(0f, meatForce), Random.Range(-meatForce, meatForce), 0f));
        }

        Destroy(gameObject);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grinder"))
        {
            Die();
        }
    }*/
}
