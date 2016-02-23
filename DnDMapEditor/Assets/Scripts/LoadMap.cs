using UnityEngine;
using System.Collections;

public class LoadMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		prefabLoad ("Map", 0, 0);
	}

	GameObject prefabLoad(string prefabPath, float x, float y)
	{
		GameObject go;

		go = (GameObject)Resources.Load (prefabPath, typeof(GameObject));

		return (GameObject)Instantiate (go, new Vector2(x,y), go.transform.rotation);

	}
	// Update is called once per frame
	void Update () {
	
	}
}
