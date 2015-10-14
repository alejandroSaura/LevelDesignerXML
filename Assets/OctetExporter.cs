using UnityEngine;
using System.Collections.Generic;
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text; 

public class OctetExporter : MonoBehaviour {

	XMLWriter writer;

	public List<ExportableData> objects = new List<ExportableData>();
	string result;

	Rect _Save, _SaveMSG;

	// Use this for initialization
	void Start () {

		_Save=new Rect(10,80,100,20); 
		_SaveMSG=new Rect(10,120,400,40);

		writer = gameObject.GetComponent<XMLWriter>();

	}


	void OnGUI() 
	{    
		
		//*************************************************** 
		// Export 
		// **************************************************    
		if (GUI.Button(_Save,"Export")) { 
			
			GUI.Label(_SaveMSG,"Export"); 
			 
			
			// Time to creat our XML! 
			result = SerializeObject(objects[0]._data);
			writer.CreateXML(result);
			Debug.Log(result);
		} 
		
		
	} 

	string SerializeObject(object pObject) 
	{ 
		string XmlizedString = null; 
		MemoryStream memoryStream = new MemoryStream(); 
		XmlSerializer xs = new XmlSerializer(typeof(ExportableData.Geometry)); 
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8); 
		xs.Serialize(xmlTextWriter, pObject); 
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
