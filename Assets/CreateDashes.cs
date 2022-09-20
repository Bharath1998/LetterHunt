using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDashes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    	int start = 0;
    	int length = 1;
		public static string target = LetterSpawner.target_word;
		print(target);
    	int n = target.Length;

        for (int i = 0; i < n; i++) 
		{
				GameObject gameObject = new GameObject();
		        gameObject.name = "go" + i.ToString();
			   	LineRenderer l = gameObject.AddComponent<LineRenderer>();
		        List<Vector3> pos = new List<Vector3>();
		        pos.Add(new Vector3(start, 15));
		        pos.Add(new Vector3(start+length, 15));
		        l.startWidth = 0.1f;
		        l.endWidth = 0.1f;
		        l.SetPositions(pos.ToArray());
		        l.useWorldSpace = true;
		        start = start + length + 1;
		        Debug.Log(start);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}