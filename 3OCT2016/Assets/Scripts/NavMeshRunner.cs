using UnityEngine;
using System.Collections;

public class NavMeshRunner : MonoBehaviour {

	public Transform target;
	private NavMeshAgent NavMeshAgent;

	void Start () 
	{
		NavMeshAgent = GetComponent<NavMeshAgent> ();
		NavMeshAgent.updateRotation = false;
	}
	
	void Update () 
	{
		NavMeshAgent.SetDestination (target.transform.position);
	}
}
