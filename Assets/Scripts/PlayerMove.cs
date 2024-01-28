using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMove : MonoBehaviour
{
    [Header("Camera Settings")]
    public CinemachineTargetGroup targetGroup;
    public float priorityWeight = 7;

    private NavMeshAgent agent;
    private Camera cam;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;

            bool hit = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo, Mathf.Infinity);

            if (hit)
            {
                agent.SetDestination(hitInfo.point);
            }
        }

        if(agent.velocity == Vector3.zero)
        {
            targetGroup.m_Targets[0].weight = 1.5f;
        }
        else
        {
            targetGroup.m_Targets[0].weight = priorityWeight;
        }
    }
}
