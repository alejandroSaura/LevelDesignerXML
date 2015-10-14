using UnityEngine;
using System.IO; 


public class XMLWriter : MonoBehaviour 
{

	string _FileLocation;
	public string _FileName = "LevelData.xml";

	// Use this for initialization
	void Start () 
	{	
		// Where we want to save and load to and from 
		_FileLocation=Application.dataPath; 
	}

	public void CreateXML(string data) 
	{ 
		StreamWriter writer; 
		FileInfo t = new FileInfo(_FileLocation+"\\"+ _FileName); 
		if(!t.Exists) 
		{ 
			writer = t.CreateText(); 
		} 
		else 
		{ 
			t.Delete(); 
			writer = t.CreateText(); 
		} 
		writer.Write(data); 
		writer.Close(); 
		Debug.Log("File written."); 
	} 
}
