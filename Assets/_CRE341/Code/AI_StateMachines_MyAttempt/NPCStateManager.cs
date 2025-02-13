using UnityEngine;

public class NPCStateManager : MonoBehaviour
{
    IState currentState;
    IdleState idleState;
    SeePlayerState seePlayerState;

    [SerializeField] float distance;

    [SerializeField] GameObject player;

    void Awake()
    {
        distance = Mathf.Infinity;
        idleState = GetComponent<IdleState>();
        seePlayerState = GetComponent<SeePlayerState>();        
        if(player == null)
        {
            player = GameObject.Find("Player");
        }
        currentState = idleState;
    }

    void SetState(IState state)
    {
        if(currentState != state)
        {
            currentState.ExitState();
            currentState = state;
            currentState.EnterState();
        }
    }

    void Update()
    {
        currentState.UpdateState();

        distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance < 10)
        {
            SetState(seePlayerState);
        }
        if (distance > 11)
        {
            SetState(idleState);
        }
    }
}
