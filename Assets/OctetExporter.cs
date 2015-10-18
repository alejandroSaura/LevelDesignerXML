using UnityEngine;
using System.Collections.Generic;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text; 

public class OctetExporter : MonoBehaviour {

	XMLWriter writer;
	MemoryStream memoryStream; 

	XmlSerializer xmlGeometrySerializer; 
	XmlSerializer xmlLightSerializer;
	XmlSerializer xmlRigidBodySerializer;
	XmlSerializer xmlCameraSerializer;

	XmlTextWriter xmlTextWriter;
	
	public List<Geometry> geometry = new List<Geometry>();
	public List<OctetLight> lights = new List<OctetLight>();
	public List<OctetRigidBody> rigidBodies = new List<OctetRigidBody>();
	public List<OctetCamera> cameras = new List<OctetCamera>();


	string result;

	Rect _Save, _SaveMSG;

	// Use this for initialization
	void Start () {

		_Save=new Rect(10,80,100,20); 
		_SaveMSG=new Rect(10,120,400,40);

		writer = gameObject.GetComponent<XMLWriter>();

		memoryStream = new MemoryStream(); 

		xmlGeometrySerializer = new XmlSerializer(typeof(List<Geometry>)); 
		xmlLightSerializer = new XmlSerializer(typeof(List<OctetLight>)); 
		xmlRigidBodySerializer = new XmlSerializer(typeof(List<OctetRigidBody>));
		xmlCameraSerializer = new XmlSerializer(typeof(List<OctetCamera>));

		xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

	}


	void OnGUI() 
	{    
		
		//*************************************************** 
		// Export 
		// **************************************************    
		if (GUI.Button(_Save,"Export")) { 
			
			GUI.Label(_SaveMSG,"Export"); 

			//Debug.Log(geometry[1]);
			 
			
			// Time to creat our XML! 
//			foreach (ExportableData obj in objects) {
//				result += SerializeObject(obj._data);
//			}
			result = "";

			if(geometry.Count > 0)
				result = SerializeObject(geometry);
			if(lights.Count > 0)
				result = SerializeObject(lights);
			if(rigidBodies.Count > 0)
				result = SerializeObject(rigidBodies);
			if(cameras.Count > 0)
				result = SerializeObject(cameras);

			writer.CreateXML(result);
			Debug.Log(result);
		} 
		
		
	} 

	string SerializeObject(object pObject) 
	{ 
		string XmlizedString = null; 
		 
		if(pObject == geometry)
		{
			xmlGeometrySerializer.Serialize(xmlTextWriter, geometry);
		}
		if(pObject == lights)
		{
			xmlLightSerializer.Serialize(xmlTextWriter, lights);
		}
		if(pObject == rigidBodies)
		{
			xmlRigidBodySerializer.Serialize(xmlTextWriter, rigidBodies);
		}
		if(pObject == cameras)
		{
			xmlCameraSerializer.Serialize(xmlTextWriter, cameras);
		}
		//xmlGeometrySerializer.Serialize(xmlTextWriter, pObject); 

		memoryStream = (MemoryStream)xmlTextWriter.BaseStream; 
		XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray()); 
		return XmlizedString; 
	} 

	string UTF8ByteArrayToString(byte[] characters) 
	{      
		UTF8Encoding encoding = new UTF8Encoding(); 
		string constructedString = encoding.GetString(characters); 
		return (constructedString); 
	} 
	
	byte[] StringToUTF8ByteArray(string pXmlString) 
	{ 
		UTF8Encoding encoding = new UTF8Encoding(); 
		byte[] byteArray = encoding.GetBytes(pXmlString); 
		return byteArray; 
	} 
	

}
