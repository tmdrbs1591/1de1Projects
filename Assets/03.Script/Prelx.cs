using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    [Header("Layer Settings")]
    public float[] layerSpeed = new float[7];
    public GameObject[] layerObjects = new GameObject[7];

    private float[] startPositions = new float[7];
    private float[] boundsSizes = new float[7];

    public float MapSpeed = 1;

    void Start()
    {
        // Calculate initial positions and bounds sizes for all layers
        for (int i = 0; i < layerObjects.Length; i++)
        {
            startPositions[i] = layerObjects[i].transform.position.x;
            boundsSizes[i] = layerObjects[i].GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    void FixedUpdate()
    {
        // Move each layer according to its speed and MapSpeed
        for (int i = 0; i < layerObjects.Length; i++)
        {
            float distance = Time.fixedDeltaTime * layerSpeed[i] * MapSpeed;
            layerObjects[i].transform.position += Vector3.left * distance;

            // Check if the layer has moved beyond its initial position
            if (layerObjects[i].transform.position.x < startPositions[i] - boundsSizes[i])
            {
                // If so, move it to the other side
                layerObjects[i].transform.position += Vector3.right * (2 * boundsSizes[i]);
            }
        }
    }
}
