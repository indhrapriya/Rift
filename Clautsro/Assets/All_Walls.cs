using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;

public class All_Walls : MonoBehaviour {

	public TextAsset GameAsset;

	float scaleX;
	float scaleY;
	float scaleZ;

	void Start () {

		ReadXML ("C:\\Users\\Owner\\Documents\\GitHub\\Rift\\Clautsro\\Assets\\config.xml");

		Vector3 scaling = new Vector3();
		scaling.x = scaleX;
		scaling.y = scaleY;
		scaling.z = scaleZ;

		Debug.Log ("Scaling started! Scale X set to: " + scaleX);
		Debug.Log ("Scale Y (ceiling) set to: " + scaleY);
		Debug.Log ("Scale Z set to: " + scaleZ);
		Transform trans = GetComponent <Transform> ();
		trans.localScale.Scale(scaling);

	}

	void Update () {
	
	}

	void ReadXML(string path){

		var serializer = new XmlSerializer(typeof(XMLVector));
		var stream = new FileStream(path, FileMode.Open);
		var container = serializer.Deserialize(stream) as XMLVector;
		stream.Close();

		scaleX = container.scaleX;
		scaleY = container.scaleY;
		scaleZ = container.scaleZ;
	}

	[XmlRoot("scaleXYZ")]
	public class XMLVector{
		
		public float scaleX;
		public float scaleY;
		public float scaleZ;
	}
}


