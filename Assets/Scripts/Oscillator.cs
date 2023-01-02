using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    bool direction = true;
    const int maxRange = 20;
    const int mixRange = 0;
    float step = 0.1f;
    [SerializeField][Range(mixRange, maxRange)] float movementFactor;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
        {
            movementFactor += step;
            if (movementFactor >= maxRange) direction = false;
        }
        else
        {
            movementFactor -= step;
            if (movementFactor <= mixRange) direction = true;
        }
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
