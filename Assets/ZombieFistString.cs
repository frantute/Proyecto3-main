using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFistString : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            Debug.Log("golpe zombie");
            other.gameObject.GetComponent<VidaPlayer>().GetHurt();
        }
    }
}
