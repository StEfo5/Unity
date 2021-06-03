using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshController : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent nma_;
    public GameObject go_player;
    Transform tr_player;
    public float distanceToPlayer, distanceTo1, distanceTo2;
    public float maxDistance;
    public bool phase = false;
    Vector3 position1 = new Vector3(7.39f, -6.53f, -17.43f),
    	position2 = new Vector3(7.39f, -6.53f, 10.19f);
    void Start()
    {
        tr_player = go_player.GetComponent<Transform>();
        nma_ = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(tr_player.position, nma_.transform.position);
        distanceTo1 = Vector3.Distance(nma_.transform.position, position1);
        distanceTo2 = Vector3.Distance(nma_.transform.position, position2);
        if(distanceTo1 < 1)phase = false;
        else if(distanceTo2 < 1)phase = true;
        if(distanceToPlayer <= maxDistance)
        	nma_.SetDestination(tr_player.position);
        else{
        	if(phase)
        		nma_.SetDestination(position1);
        	else nma_.SetDestination(position2);
        }
    }
}
