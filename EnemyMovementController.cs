using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Mathf.Sqrt(Mathf.Pow(_player.position.x - agent.transform.position.x, 2) + Mathf.Pow(_player.position.y - agent.transform.position.y, 2));
        //Debug.Log(distance<10);
        if (distance < 10)
            agent.SetDestination(_player.position);
        else
            agent.transform.position = transform.position;
    }
}
