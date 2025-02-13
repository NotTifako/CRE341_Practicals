using UnityEngine;
using UnityEngine.AI;

public class SeePlayerState : MonoBehaviour, IState
{
    NavMeshAgent navMeshAgent;
    GameObject player;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    public void EnterState()
    {
        Debug.Log("See Player - Enter");
        navMeshAgent.SetDestination(player.transform.position);
    }

    public void UpdateState()
    {
        Debug.Log("See Player - Update");
        navMeshAgent.SetDestination(player.transform.position);
    }

    public void ExitState()
    {
        Debug.Log("See Player - Exit");
        navMeshAgent.SetDestination(transform.position);
    }
}
