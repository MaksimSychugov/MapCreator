using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class EditorMap : MonoBehaviour {

	public int width;
	public int height;
	GameObject Map;
	public float xMap;
	public float yMap;
	public Sprite []choosenSprite;
	public Sprite tempSprite;
	public GameObject mapBG;
	Object [] sp;
	// Use this for initialization
	void Start () {

	
		DirectoryInfo dir = new DirectoryInfo("Assets/Sprite");
		FileInfo[] info = dir.GetFiles("*.bmp");
	//	Debug.Log (info.Length);

		sp = Resources.LoadAll ("Assets/Sprite");
		Debug.Log (sp.Length);


		Map = new GameObject ();
		Map.name = "Map";
		Map.transform.position = new Vector2 (0,0);
		mapBG.transform.parent = Map.transform;

		for(float i=0; i<width; i++)
		{
			for(float j=0; j<height; j++)
			{
				prefabLoad("cell","Block"+i+j,-height/2+j,-width/2+i).transform.parent = Map.transform;
			}
		}
		Map.transform.position = new Vector2 (xMap,yMap);

	}

	GameObject prefabLoad(string prefabPath,string name, float x, float y)
	{
		GameObject go;

		go = (GameObject)Resources.Load (prefabPath, typeof(GameObject));
		go.name = name;

		return (GameObject)Instantiate (go, new Vector3(x,y,-1), go.transform.rotation);
		
	}

	public void ChooseSprite(int choose)
	{
		tempSprite = choosenSprite [choose];
	}
	public void SaveMap()
	{
		Object prefab = EditorUtility.CreateEmptyPrefab("Assets/Resources/Map.prefab"); 
		EditorUtility.ReplacePrefab(Map, prefab, ReplacePrefabOptions.ConnectToPrefab);
		AssetDatabase.Refresh();
	}
	public void LoadMap()
	{
		Application.LoadLevel("2");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space)) 
		{
			Object prefab = EditorUtility.CreateEmptyPrefab("Assets/Map.prefab"); 
			EditorUtility.ReplacePrefab(Map, prefab, ReplacePrefabOptions.ConnectToPrefab);
		//	PrefabUtility.CreatePrefab ("Map.prefab", Map);
			//ReplacePrefab(Map, prefab, ReplacePrefabOptions.ConnectToPrefab);
			AssetDatabase.Refresh();
		}

		if (Input.GetMouseButtonDown(0)) {

			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint,Vector2.zero);
			if ( hit.collider != null )
			{
				Debug.Log( hit.collider.name );
				hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = tempSprite;
			}

		}


	
	}
}
