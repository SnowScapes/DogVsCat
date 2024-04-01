using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * 0.5f;
        if (transform.position.y > 26.0f)
        {
            Destroy(gameObject);
        }
    }
}
