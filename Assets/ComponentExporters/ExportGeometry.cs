using UnityEngine;
using System.Collections;

public class ExportGeometry : MonoBehaviour {

	OctetExporter exporter;

	Geometry data = new Geometry();

	public string geometryType; //set this one manually


	// Use this for initialization
	void Start () 
	{
		exporter = Camera.main.gameObject.GetComponent<OctetExporter>();

		data.nodeId = gameObject.GetComponent<ExportInfo>().id;

		data.geometryType = geometryType;

		data.posX = transform.position.x;
		data.posY = transform.position.y;
		data.posZ = transform.position.z;

		Vector3 rot = transform.rotation.eulerAngles;
		data.rotX = rot.x;
		data.rotY = rot.y;
		data.rotZ = rot.z;

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
