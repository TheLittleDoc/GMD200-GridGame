//Ella done wroten this
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public static class Gameplay
{
    private static Weeble.Team turn = Weeble.Team.Wug;
    public static void ToggleTurn()
    {
        if (turn == Weeble.Team.Greeble)
        {
            turn = Weeble.Team.Wug;
        } else
        {
            turn = Weeble.Team.Greeble;
        }
        Camera.main.GetComponent<CameraSpinController>().SpinCamera();
    }
    public static bool isWugTurn()
    {
        return turn == Weeble.Team.Wug;
    }
    public static bool isGreebleTurn()
    {
        return turn == Weeble.Team.Greeble;
    }
    public static Weeble.Team GetTurn()
    {
        return turn;
    }
}
