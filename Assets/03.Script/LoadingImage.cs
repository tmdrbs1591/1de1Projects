using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingImage : MonoBehaviour
{
    [SerializeField]
    Image[] backGroundImage;

    void Start()
    {
        // Ensure we have at least one image in the array
        if (backGroundImage.Length > 0)
        {
            // Get a random index within the array bounds
            int randomIndex = Random.Range(0, backGroundImage.Length);

            // Activate the selected image
            backGroundImage[randomIndex].gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No images assigned to backGroundImage array.");
        }
    }

    void Update()
    {
        // You can add update logic here if needed
    }
}
