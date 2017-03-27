using UnityEngine;

public class DiceColourScript : MonoBehaviour
{
    public GameObject dice;
    string[] DicesColours = { "Red", "Blue", "Black", "Green", "Grey", "Yellow" };
    string DiceColour = "";


    private void Start()
    {
        Coloring();
    }
    public void Coloring()
    {
        DiceColour = DicesColours[Random.Range(0, DicesColours.Length)];
        Material DiceMaterial = Resources.Load("Materials/" + DiceColour)as Material;
        dice.GetComponent<Renderer>().material = DiceMaterial;
    }

}
