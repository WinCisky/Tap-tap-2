using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //reference
    public static GameManager GM = null;
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
        if (GM == null)
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

    //activate a random button
    public void SpawnRandom()
    {
        if (!CheckAvailableButton())
        {
            int x, y;
            do
            {
                x = Random.Range(0, rowcol);
                y = Random.Range(0, rowcol);
            } while (buttons[x, y].activeInHierarchy);
            buttons[x, y].SetActive(true);
        }
        else
        {
            GameOver();
        }        

    }

    //check if all buttons are spawned
    //could be improved
    private bool CheckAvailableButton()
    {
        int active = 0;
        for (int i = 0; i < rowcol; i++)
        {
            for (int j = 0; j < rowcol; j++)
            {
                if (buttons[i, j].activeInHierarchy)
                    active++;
            }
        }
        if (active == (Mathf.Pow(rowcol, 2)))
            return true;
        return false;
    }

    //return the number of active buttons on screen
    public int ActiveButtons()
    {
        int active = 0;
        for (int i = 0; i < rowcol; i++)
        {
            for (int j = 0; j < rowcol; j++)
            {
                if (buttons[i, j].activeInHierarchy)
                    active++;
            }
        }
        return active;
    }

    public void GameOver()
    {
        //TODO
        Debug.Log("Game over!");
        MenuManager.MM.LoadScene(2);
    }
}
