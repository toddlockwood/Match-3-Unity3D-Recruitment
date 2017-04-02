using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceColourScript : MonoBehaviour
{
    public GameObject redObj;
    public GameObject greyObj;
    public GameObject blackObj;
    public GameObject yellowObj;
    public GameObject greenObj;
    public GameObject blueObj;

    private int rdnDice;
    public static float XDiceDestroy = -10;
    public static bool block = false;
    public GameObject[,] Dices = new GameObject[6, 6];
    public int AmountToMatch = 3;
    GameObject GM;

    //public GameObject dice;
    //string[] DicesColours = { "Red", "Blue", "Black", "Green", "Grey", "Yellow" };
    //public string DiceColour = "";


    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                rdnDice = Random.Range(0, 6);

                if (rdnDice == 0)
                {
                    GM = Instantiate(redObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

                    Dices[i, j] = GM;
                }
                if (rdnDice == 1)
                {
                    GM = Instantiate(blueObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

                    Dices[i, j] = GM;
                }
                if (rdnDice == 2)
                {
                    GM = Instantiate(blackObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

                    Dices[i, j] = GM;
                }
                if (rdnDice == 3)
                {
                    GM = Instantiate(yellowObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

                    Dices[i, j] = GM;
                }
                if (rdnDice == 4)
                {
                    GM = Instantiate(greenObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

                    Dices[i, j] = GM;
                }
                if (rdnDice > 4)
                {
                    GM = Instantiate(greyObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

                    Dices[i, j] = GM;
                }
            }
        }






    }

    void Update()
    {
    
        if (XDiceDestroy != -10)
        {
            rdnDice = Random.Range(0, 6);
            if (rdnDice == 0)
            {
                Instantiate(redObj, new Vector3(XDiceDestroy, 11, 0), Quaternion.identity);
            }
            if (rdnDice == 1)
            {
                Instantiate(blueObj, new Vector3(XDiceDestroy, 11, 0), Quaternion.identity);
            }
            if (rdnDice == 2)
            {
                Instantiate(blackObj, new Vector3(XDiceDestroy, 11, 0), Quaternion.identity);
            }
            if (rdnDice == 3)
            {
                Instantiate(greenObj, new Vector3(XDiceDestroy, 11, 0), Quaternion.identity);
            }
            if (rdnDice == 4)
            {
                Instantiate(greyObj, new Vector3(XDiceDestroy, 11, 0), Quaternion.identity);
            }
            if (rdnDice > 4)
            {
                Instantiate(yellowObj, new Vector3(XDiceDestroy, 11, 0), Quaternion.identity);

            }

            XDiceDestroy = -10;
            StartCoroutine(Reset());
        }

    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);
        block = false;
    }

    public void CheckOK()
    {
        List<GameObject> Dice1List = new List<GameObject>();
        List<GameObject> Dice2List = new List<GameObject>();




        ///Sprawdzanie ciągu
        for (int i = 0; i < 6; i++)
        {
            Dice1List.Clear();
            for (int j = 0; j < 6; j++)
            {

                if (Dice1List.Count == 0)
                {
                    Dice1List.Add(Dices[i, j]);
                    continue;
                }
                if (Dice1List[Dice1List.Count - 1].CompareTag(Dices[i, j].tag))
                {

                    Dice1List.Add(Dices[i, j]);

                    if (Dice1List.Count == 3)
                    {

                        Debug.Log("Równe 3!!!!!!!!");
                        foreach (GameObject GM in Dice1List)
                        {
                            if (block == false)
                            {
                                XDiceDestroy = transform.position.x;
                                Destroy(GM);
                            
                            }
                            
                        }
                        block = true;
                        Dice1List.Clear();



                    }
                    continue;
                }
                if ((Dice1List[Dice1List.Count - 1].CompareTag(Dices[i, j].tag) == false))
                {
                    Dice1List.Clear();
                    Dice1List.Add(Dices[i, j]);
                }

            }
        }




    }
}
