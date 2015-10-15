using UnityEngine;
using System.Collections;

public class ExportInfo : MonoBehaviour {

	static int idGenerator = 1;

	public int id;

	// Use this for initialization
	void Awake () {
		id = idGenerator++;
	}
}
