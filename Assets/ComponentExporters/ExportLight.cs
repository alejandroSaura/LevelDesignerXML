using UnityEngine;
using System.Collections;

public class ExportLight : MonoBehaviour {
	
	OctetExporter exporter;
	
	OctetLight data = new OctetLight();
	
	public string lightType; //set this one manually
	Light unityLight;
	
	
	// Use this for initialization
	void Start () 
	{
		exporter = GameObject.Find ("Manager").GetComponent<OctetExporter>();

		data.nodeId = gameObject.GetComponent<ExportInfo>().id;

		unityLight = gameObject.GetComponent<Light>();
		
		data.lightType = lightType;
		
		data.posX = transform.position.x;
		data.posY = transform.position.y;
		data.posZ = transform.position.z;
		
		Vector3 rot = transform.rotation.eulerAngles;
		data.rotX = rot.x;
		data.rotY = rot.y;
		data.rotZ = rot.z;
		
		data.intensity = unityLight.intensity;
		data.colorR = unityLight.color.r;
		data.colorG = unityLight.color.g;
		data.colorB = unityLight.color.b;
		
		exporter.lights.Add(data);
	}
	
	
}

// Anything we want to store in the XML file, we define it here 
public class OctetLight
{ 
	public int nodeId;
	public string lightType; //set this one manually
	public float posX, posY, posZ;
	public float rotX, rotY, rotZ;
	public float intensity;
	public float colorR;
	public float colorG;
	public float colorB;
} 
