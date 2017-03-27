using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridScript : MonoBehaviour {

    private int GridHeight = 6;
    private int GridWidth = 6;
    public GameObject DicePrefab;
    public List<GameObject> Dices = new List<GameObject>();


	void Start () {

	    for(int i=0; i<GridWidth;i++)
            {
            for(int j = 0; j < GridHeight; j++)
            {
                GameObject GM = Instantiate(DicePrefab, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                GM.transform.parent = gameObject.transform;
                Dices.Add(GM);
            }
            }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
