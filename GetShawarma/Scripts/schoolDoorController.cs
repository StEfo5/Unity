using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schoolDoorController : MonoBehaviour
{
    // Start is called before the first frame update
    bool isOpen = false;
    public GameObject go_left, go_right;
    Transform tr_left, tr_right;
    headController c_head;
    void Start()
    {
        tr_left = go_left.GetComponent<Transform>();
        tr_right = go_right.GetComponent<Transform>();
        c_head = FindObjectOfType<headController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pressE(){
    	if(isOpen){
            c_head.Move(c_head.moves[2]);
            if(Input.GetKeyDown("e")){
        		tr_left.Rotate(0,90,0);
        		tr_right.Rotate(0,-90,0);
        		isOpen = false;
            }
    	}
    	else{
            c_head.Move(c_head.moves[1]);
            if(Input.GetKeyDown("e")){
        		tr_left.Rotate(0,-90,0);
        		tr_right.Rotate(0, 90, 0);
        		isOpen = true;
            }
    	}
    }
}
