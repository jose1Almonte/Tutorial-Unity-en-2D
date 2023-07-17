using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject John;

    void Update()
    {
        if (John == null) return;
        
        Vector3 position = transform.position;
        position.x = John.transform.position.x + 0.1f;
        position.y = John.transform.position.y + 0.2f;
        transform.position = position;
    }
}
