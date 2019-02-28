using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class config : MonoBehaviour {
	//int a;
	string[] items = new string[10];
	string path;
	FileInfo f;
	string OldWriteTime;
	string NewWriteTime;
	TextMesh textmesh;
	//public static Dictionary<string,string>;
	// Use this for initialization
	void Start () {
		//string[] ch = {"111111","2"};
		path = "E:\\unity\\virtual lab\\bishe2\\Assets\\StreamingAssets\\config.txt";
		f = new FileInfo (path);
		f.LastWriteTime.ToString ();
		OldWriteTime = f.LastWriteTime.ToString ();
		textmesh = GetComponent<TextMesh>();
		//File.WriteAllLines (path,ch);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		NewWriteTime = f.LastWriteTime.ToString();
		Debug.Log (NewWriteTime);
		if (OldWriteTime != NewWriteTime && !fileisused ()) {
			try
			{
			items = File.ReadAllLines (path);
			}
			catch (System.IO.IOException)
			{
			}
			OldWriteTime = NewWriteTime;
			//File.WriteAllLines (path,ch);
			textmesh.text = "";
			foreach(string item in items) {
				if(!string.IsNullOrEmpty(item))
					textmesh.text = textmesh.text + item +'\n';
			}
		}
		f.Refresh ();
	}

	bool fileisused(){
		bool result = false;
		if (!File.Exists (path))
			return result;
		System.IO.FileStream fileStream = null;
		try
		{
			fileStream = System.IO.File.Open(path, FileMode.Open);
			result = false;
		}
		catch (System.IO.IOException)
		{
			result = true;
		}
		catch (System.Exception)
		{
			result = true;
		}
		finally
		{
			if (fileStream != null)
			{
				fileStream.Close();
			}
		}
		return result;
	}
}
