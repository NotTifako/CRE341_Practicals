using UnityEngine;

public class NPCStateManager : MonoBehaviour
{
    IState currentState;
    IdleState idleState;
    SeePlayerState seePlayerState;
    AttackState attackState;

    [SerializeField] float distance;
    [SerializeField] float seeDistance = 10;
    [SerializeField] float attackDistance = 3;
    [SerializeField] float seeHysterisis = 1;
    [SerializeField] float attackHysterisis = 1;

    [SerializeField] GameObject player;

    [SerializeField] string currSta;

    void Awake()
    {
        distance = Mathf.Infinity;
        idleState = GetComponent<IdleState>();
        seePlayerState = GetComponent<SeePlayerState>();      
        attackState = GetComponent<AttackState>();

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

        if(distance < seeDistance)
        {
            if(distance < attackDistance)
            {
                SetState(attackState);
                currSta = "Attack";
            }
            else if (distance > attackDistance + attackHysterisis)
            {
                SetState(seePlayerState);
                currSta = "See Player";
            }
        }
        else if (distance > seeDistance + seeHysterisis)
        {
            SetState(idleState);
            currSta = "Idle";
        }
    }
}
