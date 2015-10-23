using UnityEngine;
using System.Collections;

public class ExportRigidBody : MonoBehaviour {
	
	OctetExporter exporter;
	
	OctetRigidBody data = new OctetRigidBody();	

	Rigidbody rb;
	
	
	// Use this for initialization
	void Start () 
	{
		exporter = GameObject.Find ("Manager").GetComponent<OctetExporter>();

		data.nodeId = gameObject.GetComponent<ExportInfo>().id;
		
		rb = gameObject.GetComponent<Rigidbody>();

		data.mass = rb.mass;
		data.drag = rb.drag;
		data.useGravity = rb.useGravity;
		data.Kinematic = rb.isKinematic;

		
		exporter.rigidBodies.Add(data);
	}
	
	
}

// Anything we want to store in the XML file, we define it here 
public class OctetRigidBody
{ 
	public int nodeId;
	public float mass;
	public float drag;
	public bool useGravity;
	public bool Kinematic;
} 
