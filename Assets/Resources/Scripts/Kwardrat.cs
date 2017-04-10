using UnityEngine;
using System.Collections;

public class Kwardrat {
    GameObject kwardat;
    int posX;
    int posY;

    public Kwardrat(GameObject obj)
    {
        kwardat = obj;
    }

    public GameObject getKwadrat()
    {
        return kwardat;
    }
    public void setCordinates(int x, int y)
    {
        posX = x;
        posY = y;
    }

    public int getX()
    {
        return posX;
    }

    public int getY()
    {
        return posY;
    }
}
