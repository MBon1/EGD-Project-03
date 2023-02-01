using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Based on this implementation of Dynamic Drag and Drop: 
 * https://gamedevbeginner.com/how-to-move-an-object-with-the-mouse-in-unity-in-2d/#dynamic
 */
public class Thrower : MonoBehaviour
{
    private new Camera camera = null;

    [Header ("Drag and Drop")]
    [SerializeField] Rigidbody2D selectedObject;
    Vector3 offset;
    Vector3 mousePosition;

    [Space(3)]
    [Header("Throwing")]
    [SerializeField] float maxSpeed = 10;
    Vector2 mouseForce;
    Vector3 lastPosition;

    private void Awake()
    {
        camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get mouse position relative to the camera
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        // If an object is selected, determine the force applied by the mouse
        if (selectedObject)
        {
            mouseForce = (mousePosition - lastPosition) / Time.deltaTime;
            mouseForce = Vector2.ClampMagnitude(mouseForce, maxSpeed);
            lastPosition = mousePosition;
        }

        // If left-mouse-button is down
        if (Input.GetMouseButtonDown(0))
        {
            // Check if mouse is overlapping an object on Layer "Sheep" or "Meat"
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition,LayerMask.GetMask("Sheep", "Meat"));
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject.GetComponent<Rigidbody2D>();
                offset = selectedObject.transform.position - mousePosition; // Prevent it from clipping to the camera's z-position
            }
        }

        // If left-mouse-button is let o and there was an object selected, unselect it
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject.velocity = Vector2.zero;
            selectedObject.AddForce(mouseForce, ForceMode2D.Impulse);
            selectedObject = null;
        }
    }

    private void FixedUpdate()
    {
        if (selectedObject)
        {
            selectedObject.MovePosition(mousePosition + offset);
        }
    }

    Collider2D GetHighestObject(Collider2D[] colliders)
    {
        Collider2D highestObject = null;
        int highestSortingOrder = int.MinValue;
        foreach(Collider2D collider in colliders)
        {
            Renderer renderer = collider.gameObject.GetComponent<Renderer>();
            if (renderer != null && renderer.sortingOrder > highestSortingOrder)
            {
                highestSortingOrder = renderer.sortingOrder;
                highestObject = collider;
            }
        }
        return highestObject;
    }
}
