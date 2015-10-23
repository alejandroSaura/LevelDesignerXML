using UnityEngine;
using System.Collections;

public class ExportInfo : MonoBehaviour {

	static int idGenerator = 1;

	public int id;

	// Use this for initialization
	public void Init () {
		id = idGenerator++;
	}
}
