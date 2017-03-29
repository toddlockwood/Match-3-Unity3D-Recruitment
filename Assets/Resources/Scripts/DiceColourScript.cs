using System.Collections.Generic;
using UnityEngine;

public class DiceColourScript : MonoBehaviour
{
    public GameObject dice;
    string[] DicesColours = { "Red", "Blue", "Black", "Green", "Grey", "Yellow" };
    public string DiceColour = "";
    

    private void Start()
    {
            Coloring();
    }
    public void Coloring()
    {
        DiceColour = DicesColours[Random.Range(0, DicesColours.Length)];
        Material DiceMaterial = Resources.Load("Materials/" + DiceColour)as Material;
        dice.GetComponent<Renderer>().material = DiceMaterial;

        if(DiceColour == "Black")
        {
            dice.tag = "Black";
        }
        if (DiceColour == "Red")
        {
            dice.tag = "Red";
        }
        if (DiceColour == "Blue")
        {
            dice.tag = "Blue";
        }
        if (DiceColour == "Green")
        {
            dice.tag = "Green";
        }
        if (DiceColour == "Grey")
        {
            dice.tag = "Grey";
        }
        if (DiceColour == "Yellow")
        {
            dice.tag = "Yellow";
        }
        
    }



}
