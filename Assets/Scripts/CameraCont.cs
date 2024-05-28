using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    public Transform target;
    private Vector3 offset; // kameranın uzaklığı

    void Start()
    {
        offset = transform.position - target.position;    
    }

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 5 * Time.deltaTime);
    }
}
