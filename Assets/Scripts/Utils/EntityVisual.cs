using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityVisual : MonoBehaviour
{
    private Vector3 rotationAxisSpeed;

    private void Awake()
    {
        rotationAxisSpeed = new Vector3(Random.Range(-180f, 180f), Random.Range(-180f, 180f), Random.Range(-180f, 180f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxisSpeed * Time.deltaTime);        
    }
}
