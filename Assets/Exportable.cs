using UnityEngine;
using System.Collections;

public class Exportable : MonoBehaviour {

	OctetExporter exporter;

	ExportableData Edata = new ExportableData();

	public string geometryType; //set this one manually


	// Use this for initialization
	void Start () 
	{
		exporter = Camera.main.gameObject.GetComponent<OctetExporter>();

		Edata._data.geometryType = geometryType;

		Edata._data.posX = transform.position.x;
		Edata._data.posY = transform.position.y;
		Edata._data.posZ = transform.position.z;

		Vector3 rot = transform.rotation.eulerAngles;
		Edata._data.rotX = rot.x;
		Edata._data.rotY = rot.y;
		Edata._data.rotZ = rot.z;

		Edata._data.scaleX = transform.localScale.x;
		Edata._data.scaleY = transform.localScale.y;
		Edata._data.scaleZ = transform.localScale.z;

		exporter.objects.Add(Edata);
	}


}

public class ExportableData 
{ 
	// We have to define a default instance of the structure 
	public Geometry _data; 
	// Default constructor doesn't really do anything at the moment 
	public ExportableData() { } 
	
	// Anything we want to store in the XML file, we define it here 
	public struct Geometry 
	{ 
		public string geometryType; //set this one manually
		public float posX, posY, posZ;
		public float rotX, rotY, rotZ;
		public float scaleX, scaleY, scaleZ; 
	} 
}
