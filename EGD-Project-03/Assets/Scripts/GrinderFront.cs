using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrinderFront : MonoBehaviour
{
    float colliderX;

    // Start is called before the first frame update
    void Start()
    {
        colliderX = this.GetComponent<BoxCollider2D>().size.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
