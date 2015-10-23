using UnityEngine;
using System.Collections;

public class ExportCamera : MonoBehaviour {
	
	OctetExporter exporter;
	
	OctetCamera data = new OctetCamera();
	
	string cameraType; 
	Camera unityCamera;
	
	
	// Use this for initialization
	void Start () 
	{
		exporter = GameObject.Find ("Manager").GetComponent<OctetExporter>();

		data.nodeId = gameObject.GetComponent<ExportInfo>().id;		
		unityCamera = gameObject.GetComponent<Camera>();

		if(unityCamera == Camera.main)
		{
			data.cameraType = "main";
		}else
		{
			data.cameraType = "secondary";
		}
		
		data.posX = transform.position.x;
		data.posY = transform.position.y;
		data.posZ = transform.position.z;
		
		Vector3 rot = transform.rotation.eulerAngles;
		data.rotX = rot.x;
		data.rotY = rot.y;
		data.rotZ = rot.z;
		
		exporter.cameras.Add(data);
	}
	
	
}

// Anything we want to store in the XML file, we define it here 
public class OctetCamera
{ 
	public int nodeId;
	public string cameraType;
	public float posX, posY, posZ;
	public float rotX, rotY, rotZ;

} 
