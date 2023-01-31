using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    SurfaceEffector2D surfaceEffector;
    // Start is called before the first frame update
    void Start()
    {
        surfaceEffector = gameObject.GetComponent<SurfaceEffector2D>();
        //SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeDirection(bool change)
    {
        if(change)
            surfaceEffector.speed *= -1;
        SetColor();
    }

    private void SetColor()
    {
        if (surfaceEffector.speed < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if(surfaceEffector.speed > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public float GetSpeed()
    {
        return surfaceEffector.speed;
    }

    /*private void OnEnable()
    {
        ConveyorBeltSwitch.OnSetConveyorDirection += ChangeDirection;
    }

    private void OnDisable()
    {
        ConveyorBeltSwitch.OnSetConveyorDirection -= ChangeDirection;
    }*/

    private void ChangeDirection()
    {
        surfaceEffector.speed *= -1;
        SetColor();
    }
}
