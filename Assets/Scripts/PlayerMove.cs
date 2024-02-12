using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMove : MonoBehaviour
{
    [Header("Camera Settings")]
    public CinemachineTargetGroup targetGroup;
    public CinemachineVirtualCamera virtualCamera;
    public float priorityWeight = 7;
    public float idleWeight = 1.5f;
    public float tweenSpeed = 4;

    private NavMeshAgent agent;
    private Camera cam;
    private Rigidbody rb;
    private float tweenWeight;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        tweenWeight = idleWeight;
        GameManager.INSTANCE.onMovePlayer += SetDestination;
    }

    private void Update()
    {
        if (GameManager.INSTANCE.gameIsPaused)
        {
            return;
        }

        if (agent.velocity == Vector3.zero)
        {
            tweenWeight = Mathf.Lerp(tweenWeight, idleWeight, 4 * Time.deltaTime);
            targetGroup.m_Targets[0].weight = tweenWeight;
        }
        else
        {
            tweenWeight = Mathf.Lerp(tweenWeight, priorityWeight, tweenSpeed * Time.deltaTime);
            targetGroup.m_Targets[0].weight = tweenWeight;
        }
    }

    public void SetDestination()
    {
        RaycastHit hitInfo;

        bool hit = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity);

        if (hit)
        {
            agent.SetDestination(hitInfo.point);
        }
    }
}
