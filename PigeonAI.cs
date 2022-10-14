using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PigeonAI : MonoBehaviour
{
    //Aan geven waar de boss aggro op moet worden. / Moet gaan volgen.
    [SerializeField] private Transform target;

    // NavMeshAgent ophalen.
    private NavMeshAgent navMeshAgent;

    //Wanneer script wakker word doe dit.
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    //Bij elke frame doe dit.
    private void Update()
    {
        //Aan geven wat waarnaartoe moet lopen.
        navMeshAgent.destination = target.position;
    }
}
