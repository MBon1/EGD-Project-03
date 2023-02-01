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

        Vector2 pos = this.transform.position;
        Vector2 cPos = collision.transform.position;
        if (pos.x - colliderX <= cPos.x && pos.x + colliderX >= cPos.x)
        {
            SpriteRenderer sr = collision.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                if (collision.gameObject.layer == LayerMask.NameToLayer("Sheep") &&
                    pos.y <= cPos.y && collision.GetComponent<Rigidbody2D>().velocity.y < 0)
                {
                    sr.sortingOrder = -2;
                    collision.gameObject.layer = LayerMask.NameToLayer("Dead Sheep");
                }
                if (collision.gameObject.layer == LayerMask.NameToLayer("Dead Sheep") &&
                    pos.y > cPos.y && collision.GetComponent<Rigidbody2D>().velocity.y > 0)
                {
                    sr.sortingOrder = 0;
                    collision.gameObject.layer = LayerMask.NameToLayer("Sheep");
                }
            }
        }
    }
}
