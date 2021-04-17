using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    // Start is called before the first frame update
    float xRotate, sens = 3f, yRotate;
    public GameObject player;
    PlayerController pl_contr;
    void Start()
    {
    	pl_contr = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(pl_contr.isRotating){
        	xRotate = Mathf.Clamp(xRotate - Input.GetAxis("Mouse Y")*sens, -90, 90);
        	yRotate = yRotate + Input.GetAxis("Mouse X")*sens;
        	transform.rotation = Quaternion.Euler(xRotate, yRotate, 0f);
        }
    }
}
