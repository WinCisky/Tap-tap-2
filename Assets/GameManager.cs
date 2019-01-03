using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //reference
    public GameManager GM;
    //number of rows & cloumns
    static int rowcol = 4;
    //button position
    private Vector2[,] position = new Vector2[rowcol, rowcol];
    //button instances
    private GameObject[,] buttons = new GameObject[rowcol, rowcol];
    //button prefab
    public GameObject button;
    //button father
    public Transform button_father;

    // Before the start
    void Awake()
    {
        //ref assignment
        GM = this;
        //variables def
        for (int i = 0; i < rowcol; i++)
        {
            for (int j = 0; j < rowcol; j++)
            {
                //assign the position of the points in the scene
                position[i, j] = Camera.main.ScreenToWorldPoint(new Vector3(
                    (Screen.width / rowcol) * i + (Screen.width / rowcol) / 2,
                    (Screen.height / (rowcol+2)) * j + (Screen.height / (rowcol+2)) / 2)); //some space for the scoreboard
                //create the g.o. for each point
                buttons[i,j] = Instantiate(button, new Vector3(position[i, j].x, position[i, j].y, 0), Quaternion.identity, button_father);
                buttons[i, j].SetActive(false);
            }
        }
    }
}
