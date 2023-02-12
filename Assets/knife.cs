using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    public GameObject rightHand;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = rightHand.transform.position;
        gameObject.transform.rotation = rightHand.transform.rotation;
    }
}
