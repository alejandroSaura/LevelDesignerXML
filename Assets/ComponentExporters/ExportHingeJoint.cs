using UnityEngine;
using System.Collections;

public class ExportHingeJoint : MonoBehaviour {

	OctetExporter exporter;
	
	OctetHingeJoint data = new OctetHingeJoint();	
	
	HingeJoint hj;
	
	
	// Use this for initialization
	void Start () 
	{
		exporter = GameObject.Find ("Manager").GetComponent<OctetExporter>();
		
		data.nodeIdFrom = gameObject.GetComponent<ExportInfo>().id;
		
		hj = gameObject.GetComponent<HingeJoint>();
		
		data.nodeIdTO = hj.connectedBody.gameObject.GetComponent<ExportInfo>().id;

		data.axisX = hj.axis.x;
		data.axisY = hj.axis.y;
		data.axisZ = hj.axis.z;		

		data.anchorX = hj.anchor.x * transform.localScale.x;
		data.anchorY = hj.anchor.y * transform.localScale.y;
		data.anchorZ = hj.anchor.z * transform.localScale.z;

		data.anchorBX = hj.connectedAnchor.x * hj.connectedBody.transform.localScale.x;
		data.anchorBY = hj.connectedAnchor.y * hj.connectedBody.transform.localScale.y;
		data.anchorBZ = hj.connectedAnchor.z * hj.connectedBody.transform.localScale.z;
		
		exporter.hingeJoints.Add(data);
	}
	
	
}

// Anything we want to store in the XML file, we define it here 
public class OctetHingeJoint
{ 
	public int nodeIdFrom;
	public int nodeIdTO;
	public float axisX;
	public float axisY;
	public float axisZ;
	public float anchorX;
	public float anchorY;
	public float anchorZ;
	public float anchorBX;
	public float anchorBY;
	public float anchorBZ;

} 

