using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    public GameObject catalog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new UnityEngine.Ray(transform.position, transform.forward);
        RaycastHit hitData;

        Physics.Raycast(ray, out hitData, 2);
        Debug.DrawLine(transform.position, hitData.point, Color.red);

        if (hitData.collider != null)
        {
            if (hitData.transform.tag == "Shop")
            {
                
                if (Input.GetKey(KeyCode.E))
                {
                    catalog.SetActive(true);
                }
            }
        }
    }


}
