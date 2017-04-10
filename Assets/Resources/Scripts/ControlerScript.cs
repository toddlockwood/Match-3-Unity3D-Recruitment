using UnityEngine;
using System.Collections;

public class ControlerScript : DiceColourScript {

	// Use this for initialization
	void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnMouseDown()
    {
        CheckOK();



        //if (DiceColourScript.block == false)
        //{
        //    DiceColourScript.XDiceDestroy = transform.position.x;
        //    Destroy(gameObject);
        //    DiceColourScript.block = true;
        //}
    }
}
