using UnityEngine;
using System.Collections;

public class ExportSpringJoint : MonoBehaviour {
	
	OctetExporter exporter;
	
	OctetSpringJoint data = new OctetSpringJoint();	
	
	SpringJoint sj;
	
	
	// Use this for initialization
	void Start () 
	{
		exporter = GameObject.Find ("Manager").GetComponent<OctetExporter>();
		
		data.nodeIdFrom = gameObject.GetComponent<ExportInfo>().id;

		sj = gameObject.GetComponent<SpringJoint>();
		
		data.nodeIdTO = sj.connectedBody.gameObject.GetComponent<ExportInfo>().id;		

		data.springFactor = sj.spring;
		
		data.anchorX = sj.anchor.x * transform.localScale.x;
		data.anchorY = sj.anchor.y * transform.localScale.y;
		data.anchorZ = sj.anchor.z * transform.localScale.z;
		
		data.anchorBX = sj.connectedAnchor.x * sj.connectedBody.transform.localScale.x;
		data.anchorBY = sj.connectedAnchor.y * sj.connectedBody.transform.localScale.y;
		data.anchorBZ = sj.connectedAnchor.z * sj.connectedBody.transform.localScale.z;
		
		exporter.springJoints.Add(data);
	}
	
	
}

// Anything we want to store in the XML file, we define it here 
public class OctetSpringJoint
{ 
	public int nodeIdFrom;
	public int nodeIdTO;

	public float anchorX;
	public float anchorY;
	public float anchorZ;
	public float anchorBX;
	public float anchorBY;
	public float anchorBZ;

	public float springFactor;
	
} 

