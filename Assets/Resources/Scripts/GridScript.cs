using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GridScript : MonoBehaviour
{

    private int GridHeight = 6;
    private int GridWidth = 6;
    public GameObject DicePrefab;
    GameObject GM;
    public GameObject[,]Dices = new GameObject[6,6];
    public int AmountToMatch = 3;


	void Start () {
        MakeArray();
    
        
    }
    void MakeArray()
    {

        for (int i = 0; i < GridHeight; i++)
        {


            for (int j = 0; j < GridWidth; j++)
            {
                GM = Instantiate(DicePrefab, new Vector3(i, j, 0), Quaternion.identity) as GameObject;
                GM.transform.parent = gameObject.transform;
                Dices[i, j] = GM;
                
            }
        }
    }
	void CheckOK()
    {
        List<GameObject> Dice1List = new List<GameObject>();
        List<GameObject> Dice2List = new List<GameObject>();




        ///Sprawdzanie ciągu
        for (int i = 0; i < GridHeight; i++)
        {
            Dice1List.Clear();
            for (int j = 0; j < GridWidth; j++)
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
                        Dices[i, j] = null;
                        Dices[i - 1, j] = null;
                        Dices[i - 2, j] = null;
                        Debug.Log("Równe 3!!!!!!!!");
                        foreach (GameObject GM in Dice1List)
                        {
                            Destroy(GM);
                            

                        }
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

            //for (int i = 0; i<GridHeight; i++)
            //{
            //    Dice2List.Clear();
            //    for (int j = 0; j<GridWidth; j++)
            //    {

            //        if (Dice2List.Count == 0)
            //        {
            //            Dice2List.Add(Dices[j, i]);
            //            continue;
            //        }
            //        if (Dice2List[Dice2List.Count - 1].CompareTag(Dices[j, i].tag))
            //        {

            //            Dice2List.Add(Dices[j, i]);

            //            if (Dice2List.Count == 3)
            //            {
            //                Debug.Log("Równe 3!!!!!!!!");
            //                foreach (GameObject GM in Dice2List)
            //                {
            //                    Destroy(GM);

            //                }
            //                Dice2List.Clear();
            //            }
            //            continue;
            //        }
            //        if ((Dice2List[Dice2List.Count - 1].CompareTag(Dices[j, i].tag) == false))
            //        {
            //            Dice2List.Clear();
            //            Dice2List.Add(Dices[j, i]);
            //        }

            //    }

            //}

        }
    void RefactorDices()
    {
        List<GameObject> DiceListRefactor = new List<GameObject>();

        for(int i = 0;i<GridHeight;i++)
        {

            for( int j = 0;j<GridWidth;j++)
            {
                if(Dices[i,j] == null)
                {
                    for (int k = i + 2; k < GridHeight; k++)
                    {
                        DiceListRefactor.Add(Dices[k, j]);

                        foreach (GameObject GM in DiceListRefactor)
                        {
                            Dices[k, j] = Dices[i, j];
                            
                        }
                    }

                }
            }
        }

    }


    void Update()
    {


        CheckOK();
        RefactorDices();

    }
}
