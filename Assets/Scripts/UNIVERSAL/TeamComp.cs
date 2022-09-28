using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TeamComp : MonoBehaviour
{
    public enum teamColour
    {
        Neutral,
        Red,
        Blue,
    };

    private teamColour myTeamColour;

    public void SetMyTeam(int x)
    {
        switch (x)
        {
            case 0:
                myTeamColour = teamColour.Neutral;
                break;

            case 1:
                myTeamColour = teamColour.Blue;
                break;

            case 2:

                myTeamColour = teamColour.Red;
                break;
        }
    }

    public int WhatsMyTeam()
    {
        return (int)myTeamColour;
    }
}