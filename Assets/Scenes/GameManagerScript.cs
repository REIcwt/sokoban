using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    int[] map;

    //print the array
    void printArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    //put the 1 (player)
    int GetPlayerIndex()
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }

    //move the 1(player)
    bool MoveNumber(int number,int moveFrom,int moveTo)
    {
        if(moveFrom < 0 || moveTo >= map.Length)
        {
            //outside the regine
            return false;
        }
        //if next array is 2(box)
        if (map[moveTo]==2)
        {
            //see is move to left(1) or right(-1)
            int velocity = moveTo - moveFrom;
            bool success=MoveNumber(2,moveTo,moveTo +  velocity);
            if (!success)
            {
                return false;
            }
        }

        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }


    // Start is called before the first frame update
    void Start()
    {
        map = new int[] { 0, 2, 0, 1, 0, 2, 0, 0, 0, };
        printArray();
    }

    // Update is called once per frame
    void Update()
    {
        ///input to move RIGHT
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int playerIndex= GetPlayerIndex();

            MoveNumber(1, playerIndex, playerIndex + 1);
            printArray();
        }

        ///input to move LEFT
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int playerIndex = GetPlayerIndex();

            MoveNumber(1, playerIndex, playerIndex - 1);
            printArray();
        }

    }
}
