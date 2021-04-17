using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float v, h, xRotate, yRotate, sens = 3f;
    Rigidbody rb;
    public GameObject panel, text, panel2, door, key;
    RaycastHit objects;
    public bool isRotating = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("Act1", 0.01f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        //передвижение
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        rb.velocity = transform.forward * v * 10f;
        rb.AddForce(transform.right * h * 100f);
        //повороты
        
        if(isRotating){
            yRotate = yRotate + Input.GetAxis("Mouse X")*sens;
            transform.rotation = Quaternion.Euler(0f, yRotate, 0f);
        }
        //лучи
        Debug.DrawRay(transform.position, transform.forward * 0.5f, Color.yellow);
    }

    void Act1(){
        if (Physics.Raycast(transform.position, transform.forward, out objects,  4f))
        {
            if(objects.collider.gameObject.tag == "keyer"){
                panel.SetActive(true);
                isRotating = false;
                CancelInvoke();
                InvokeRepeating("Act05", 0.01f, 0.01f);
            }
        }
    }

    void Act05(){
        if (Physics.Raycast(transform.position, transform.forward, out objects,  4f))
        {
            if(objects.collider.gameObject.tag == "door"){
                text.SetActive(true);
                CancelInvoke();
                Invoke("HideText", 1f);
                InvokeRepeating("Act2", 0.01f, 0.01f);
            }
        }
    }

    void Act2(){
        if(Physics.Raycast(transform.position, transform.forward, out objects, 4f)){
            if(objects.collider.gameObject.tag == "keyer"){
                panel2.SetActive(true);
                isRotating = false;
                CancelInvoke();
                InvokeRepeating("Act3", 0.01f, 0.01f);
            }
        }
    }

    void Act3(){
        if(Physics.Raycast(transform.position, transform.forward, out objects, 4f)){
            if(objects.collider.gameObject.tag == "door"){
                door.SetActive(false);
                key.SetActive(false);
            }
        }
    }

    void HideText(){
        text.SetActive(false);
    }
}
