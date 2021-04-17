using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel, panel2, panel1, player, key;
    PlayerController pl_contr;
    void Start()
    {
        player = GameObject.Find("Player");
        pl_contr = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HidePanel(){
    	panel.SetActive(false);
    	panel1.SetActive(true);
    }
    public void HidePanel1(){
    	panel1.SetActive(false);
    	pl_contr.isRotating = true;
    }
    public void HidePanel2(){
    	panel2.SetActive(false);
    	pl_contr.isRotating = true;
    	key.SetActive(true);
    }
}
