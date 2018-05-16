using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour {

    GameObject temp;

    private void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Player")
        {
            temp = c.gameObject;
            temp.GetComponent<PlayerInput>();
            Destroy(temp);
        }
    }
}
