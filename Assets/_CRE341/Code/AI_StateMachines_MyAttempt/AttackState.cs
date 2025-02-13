using UnityEngine;

public class AttackState : MonoBehaviour, IState
{
    Renderer rendererRef;
    Color startColor;

    void Awake()
    {
        rendererRef = GetComponentInChildren<Renderer>();
        startColor = rendererRef.material.color;
    }

    public void EnterState()
    {
        Debug.Log("Attack - Enter");

        rendererRef.material.color = Color.red;
    }

    public void UpdateState()
    {
        Debug.Log("Attack - Update");
    }

    public void ExitState()
    {
        Debug.Log("Attack - Exit");

        rendererRef.material.color = startColor;
    }
}
