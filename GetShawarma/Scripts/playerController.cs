using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    float v, h;
    public float sens, vSpeed, hSpeed, yRotate;
    Rigidbody rb;
    public GameObject go_falling, go_reason, go_victory; 
    bool closesMessage = false;
    headController c_head;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        c_head = FindObjectOfType<headController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(closesMessage){
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
            rb.velocity = transform.forward * v * vSpeed;
            rb.AddForce(transform.right * h * hSpeed);

            yRotate = yRotate + Input.GetAxis("Mouse X") * sens;
            transform.rotation = Quaternion.Euler(0f, yRotate, 0f);
        }
    }
    void OnCollisionEnter(Collision obj){
        if(obj.gameObject.tag == "teacher"){
            Fall(c_head.reasons[0]);
        }
        else if(obj.collider.tag == "Finish"){
            if(c_head.havesMask){
                go_victory.SetActive(true);
                Destroy(obj.gameObject);
            }
            else Fall(c_head.reasons[1]);
        }
    }

    public void CloseMessage(){
        closesMessage = true;
    }

    void Fall(string reason){
        go_falling.SetActive(true);
        go_reason.GetComponent<Text>().text = reason;
        closesMessage = false;
        c_head.OpenMessage();
    }
}
