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
	XmlSerializer xmlHingeJointSerializer;
	XmlSerializer xmlSpringJointSerializer;

	XmlTextWriter xmlTextWriter;
	
	public List<Geometry> geometry = new List<Geometry>();
	public List<OctetLight> lights = new List<OctetLight>();
	public List<OctetRigidBody> rigidBodies = new List<OctetRigidBody>();
	public List<OctetCamera> cameras = new List<OctetCamera>();
	public List<OctetHingeJoint> hingeJoints = new List<OctetHingeJoint>();
	public List<OctetSpringJoint> springJoints = new List<OctetSpringJoint>();


	string result;

	Rect _Save, _SaveMSG;

	GameObject[] _objects;


	void Awake ()
	{

		_objects = GameObject.FindGameObjectsWithTag("export");
		foreach (GameObject o in _objects)
		{
			//Get objects to export
			ExportInfo info = o.AddComponent<ExportInfo>();
			info.Init();

			//Add export components as needed
			#region
			MeshFilter m = o.GetComponent<MeshFilter>();
			if(m  != null)
			{
				ExportGeometry e = o.AddComponent<ExportGeometry>();
				if(m.mesh.name == "Cube Instance")
				{
					e.geometryType = "Cube";
				}else if(m.mesh.name == "Sphere Instance")				
				{
					e.geometryType = "Sphere";
				}
			}

			Rigidbody r = o.GetComponent<Rigidbody>();
			if(r  != null)
			{
				o.AddComponent<ExportRigidBody>();
			}

			Camera c = o.GetComponent<Camera>();
			if(c  != null)
			{
				o.AddComponent<ExportCamera>();
			}

			Light l = o.GetComponent<Light>();
			if(l  != null)
			{				
				ExportLight e = o.AddComponent<ExportLight>();
				if (l.type == LightType.Point)
				{
					e.lightType = "Point";
				}
			}

			HingeJoint h = o.GetComponent<HingeJoint>();
			if(h  != null)
			{
				o.AddComponent<ExportHingeJoint>();
			}

			SpringJoint s = o.GetComponent<SpringJoint>();
			if(s != null)
			{
				o.AddComponent<ExportSpringJoint>();
			}

			#endregion

		}
	}



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
		xmlHingeJointSerializer = new XmlSerializer(typeof(List<OctetHingeJoint>));
		xmlSpringJointSerializer = new XmlSerializer(typeof(List<OctetSpringJoint>));

		xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

	}


	void OnGUI() 
	{   		
		//*************************************************** 
		// Export 
		// **************************************************    
		if (GUI.Button(_Save,"Export")) { 
			
			GUI.Label(_SaveMSG,"Export"); 

			result = "";

			if(geometry.Count > 0)
				result = SerializeObject(geometry);
			if(lights.Count > 0)
				result = SerializeObject(lights);
			if(rigidBodies.Count > 0)
				result = SerializeObject(rigidBodies);
			if(cameras.Count > 0)
				result = SerializeObject(cameras);
			if(hingeJoints.Count >0)
				result = SerializeObject(hingeJoints);
			if(springJoints.Count >0)
				result = SerializeObject(springJoints);

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
		if(pObject == hingeJoints)
		{
			xmlHingeJointSerializer.Serialize(xmlTextWriter, hingeJoints);
		}
		if(pObject == springJoints)
		{
			xmlSpringJointSerializer.Serialize(xmlTextWriter, springJoints);
		}

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
