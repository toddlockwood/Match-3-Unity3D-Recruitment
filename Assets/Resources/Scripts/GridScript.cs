using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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
        for (int i = 0; i<GridHeight;i++)
        {

            for(int j = 0; j<GridWidth;j++)
            {
                
                if(Dice1List == null)
                {
                    Dice1List.Add(Dices[i, j]);
                    continue;
                }
                if (Dice1List[Dice1List.Count-1].CompareTag(Dices[i,j].tag))
                {
                    Dice1List.Add(Dices[i, j]);

                    if (Dice1List.Count == 2)
                    {
                        Debug.Log("Równe 3!!!!!!!!");
                    }
                    continue;
                }
                if (Dice1List[Dice1List.Count - 1].CompareTag(Dices[i, j].tag) == false)
                {
                    Dice1List.Clear();
                }

            }

        }

    }


    void Update()
    {
        CheckOK();
    }
}
