using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class headController : MonoBehaviour
{
    // Start is called before the first frame update
    float xRotate;
    public float distance;
    public GameObject go_player, go_press, go_mask, go_officeDoor,
    	go_wall, go_message, go_move;
    bool officeDoorIsOpen = false, closesMessage = false;
    public bool havesMask = false;
    playerController c_player;
    RaycastHit obj;
    public string[] reasons = {
        "Не смог сбежать",
        "Убит ковидом"
    };
    public string[] moves = {
        "взять",
        "открыть",
        "закрыть",
    };
    void Start()
    {
        c_player = go_player.GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(closesMessage){
            xRotate = Mathf.Clamp(xRotate - Input.GetAxis("Mouse Y") * c_player.sens, -90, 90);
            transform.rotation = Quaternion.Euler(xRotate, c_player.yRotate, 0f);
        }

        Debug.DrawRay(transform.position, transform.forward, Color.yellow);
        if(Physics.Raycast(transform.position, transform.forward, out obj, distance)){
            if(obj.collider.gameObject.tag == "mask"){
                Move(moves[0]);
                if(Input.GetKeyDown("e")){
                    go_mask.SetActive(false);
                    havesMask = true;
                }
            }
            else if(obj.collider.gameObject.tag == "officeDoor"){
                if(officeDoorIsOpen){
                    Move(moves[2]);
                    if(Input.GetKeyDown("e")){
                        go_officeDoor.transform.Rotate(0, -90, 0);
                        officeDoorIsOpen = false;
                    }
                }
                else {
                    Move(moves[1]);
                    if(Input.GetKeyDown("e")){
                        go_officeDoor.transform.Rotate(0, 90, 0);
                        officeDoorIsOpen = true;
                    }
                }
            }
            else if(obj.collider.gameObject.tag == "schoolDoor"){
                FindObjectOfType<schoolDoorController>().pressE();
            }
            else go_press.SetActive(false);
        }
        else go_press.SetActive(false);
    }

    public void CloseMessage(){
        closesMessage = true;
        c_player.CloseMessage();
        go_message.SetActive(false);
    }

    public void TryAgain(){
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenMessage(){
        closesMessage = false;
    }

    public void Move(string move){
        go_press.SetActive(true);
        go_move.GetComponent<Text>().text = "Нажмите Е, чтобы " + move;
    }
}
