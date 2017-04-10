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

    public int rdnDice;
    public static float XDiceDestroy = -10;
    public static bool block = false;
    public static Kwardrat[,] Dices = new Kwardrat[6, 6];
    public int AmountToMatch = 3;
    public GameObject GM;




    public void Start()
    {
        GridStarter();

    }

    public void GridStarter()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                rdnDice = Random.Range(0, 6);

                if (rdnDice == 0)
                {
                    GM = Instantiate(redObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

                 
                }
                if (rdnDice == 1)
                {
                    GM = Instantiate(blueObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

                
                }
                if (rdnDice == 2)
                {
                    GM = Instantiate(blackObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

                
                }
                if (rdnDice == 3)
                {
                    GM = Instantiate(yellowObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

                }
                if (rdnDice == 4)
                {
                    GM = Instantiate(greenObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

            
                }
                if (rdnDice > 4)
                {
                    GM = Instantiate(greyObj, new Vector3(i, j, 0), Quaternion.identity) as GameObject;

                
                }
                GM.transform.parent = gameObject.transform;
                Dices[i, j] = new Kwardrat(GM);
                Dices[i, j].setCordinates(i, j);

            }
        }
    }
    /// <summary>
    /// //////////////////NOWE KLOCKI
    /// </summary>
    void Update()
    {
        
        if (XDiceDestroy != -10)
        {
            for (int i = 11; i < 14; i++)
            {

                rdnDice = Random.Range(0, 6);
                if (rdnDice == 0)
                {
                    GM = Instantiate(redObj, new Vector3(XDiceDestroy, i, 0), Quaternion.identity) as GameObject;
                    
                }
                if (rdnDice == 1)
                {
                    GM = Instantiate(blueObj, new Vector3(XDiceDestroy, i, 0), Quaternion.identity) as GameObject;
                }
                if (rdnDice == 2)
                {
                    GM = Instantiate(blackObj, new Vector3(XDiceDestroy, i, 0), Quaternion.identity) as GameObject;
                }
                if (rdnDice == 3)
                {
                    GM = Instantiate(greenObj, new Vector3(XDiceDestroy, i, 0), Quaternion.identity) as GameObject;
                }
                if (rdnDice == 4)
                {
                    GM = Instantiate(greyObj, new Vector3(XDiceDestroy, i, 0), Quaternion.identity) as GameObject;
                }
                if (rdnDice > 4)
                {
                    GM = Instantiate(yellowObj, new Vector3(XDiceDestroy, i, 0), Quaternion.identity) as GameObject;

                }



            }
            XDiceDestroy = -10;

        }

    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);

    }
    /// <summary>
    /// SPRAWDZANIE CIĄGU czy 3 są poprawne pod rząd
    /// </summary>
    public void CheckOK()
    {
        List<Kwardrat> Dice1List = new List<Kwardrat>();
        List<Kwardrat> Dice2List = new List<Kwardrat>();
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
                if (Dice1List[Dice1List.Count - 1].getKwadrat().CompareTag(Dices[i, j].getKwadrat().tag))
                {

                    Dice1List.Add(Dices[i, j]);

                    if (Dice1List.Count == 3)
                    {
                        Debug.Log("Równe 3!!!!!!!!");
                        foreach (Kwardrat GM in Dice1List)
                        {
                            
                        XDiceDestroy = GM.getKwadrat().transform.position.x;
                        Destroy(GM.getKwadrat());
                        }
                        
                        Dice1List.Clear();

                    }
                    continue;
                }
                if ((Dice1List[Dice1List.Count - 1].getKwadrat().CompareTag(Dices[i, j].getKwadrat().tag) == false))
                {
                    Dice1List.Clear();
                    Dice1List.Add(Dices[i, j]);
                }

            }
        }




    }

}
