using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Material matTank1;
    public Material matTank2;

    public bool isTank1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChosenTank1()
    {
        isTank1 = true;
    }

    public void ChosenTank2()
    {
        isTank1 = false;
    }

    public void ChangeColorTankBlue()
    {
        if(isTank1)
        {
            matTank1.color = Color.blue;
        }
        else
        {
            matTank2.color = Color.blue;
        }      
    }

    public void ChangeColorTankRed()
    {
        if (isTank1)
        {
            matTank1.color = Color.red;
        }
        else
        {
            matTank2.color = Color.red;
        }
    }

    public void ChangeColorTankGreen()
    {
        if (isTank1)
        {
            matTank1.color = Color.green;
        }
        else
        {
            matTank2.color = Color.green;
        }
    }


    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
