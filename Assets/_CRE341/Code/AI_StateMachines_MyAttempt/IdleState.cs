using UnityEngine;

public class IdleState : MonoBehaviour, IState
{
    Renderer objRenderer;
    Color startColor;

    void Start()
    {
        objRenderer = GetComponentInChildren<Renderer>();
        startColor = objRenderer.material.color;
    }

    public void EnterState()
    {
        Debug.Log("Idle - Enter");
        objRenderer.material.color = Random.ColorHSV();
    }

    public void UpdateState()
    {
        Debug.Log("Idle - Update");
    }

    public void ExitState()
    {
        Debug.Log("Idle - Exit");
        objRenderer.material.color = startColor;
    }
}
