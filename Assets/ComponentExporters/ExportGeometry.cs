using UnityEngine;
using System.Collections;

public class ExportGeometry : MonoBehaviour {

	OctetExporter exporter;



	Geometry data = new Geometry();

	public string geometryType; //set this one manually


	// Use this for initialization
	void Start () 
	{
		exporter = GameObject.Find ("Manager").GetComponent<OctetExporter>();


		data.nodeId = gameObject.GetComponent<ExportInfo>().id;

		data.geometryType = geometryType;

		data.posX = transform.position.x;
		data.posY = transform.position.y;
		data.posZ = transform.position.z;

//		Quaternion rot1 = Quaternion.FromToRotation(Vector3.up, transform.up);
//		Quaternion rot2 = Quaternion.FromToRotation(Vector3.forward, transform.forward);
//		Quaternion rotTot = rot1 * rot2;
//
//		Vector3 rot = rotTot.eulerAngles;
		data.rotX = transform.localRotation.eulerAngles.x;
		data.rotY = transform.localRotation.eulerAngles.y;
		data.rotZ = transform.localRotation.eulerAngles.z;


		data.scaleX = transform.localScale.x;
		data.scaleY = transform.localScale.y;
		data.scaleZ = transform.localScale.z;

		exporter.geometry.Add(data);
	}


}

// Anything we want to store in the XML file, we define it here 
public class Geometry
{ 
	public int nodeId;
	public string geometryType; //set this one manually
	public float posX, posY, posZ;
	public float rotX, rotY, rotZ;
	public float scaleX, scaleY, scaleZ; 
} 
