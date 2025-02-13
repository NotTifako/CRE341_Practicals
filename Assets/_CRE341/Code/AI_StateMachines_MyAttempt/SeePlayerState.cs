using UnityEngine;

public class SeePlayerState : MonoBehaviour, IState
{
    public void EnterState()
    {
        Debug.Log("See Player - Enter");
    }

    public void UpdateState()
    {
        Debug.Log("See Player - Update");
    }

    public void ExitState()
    {
        Debug.Log("See Player - Exit");
    }
}
