using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalValues
{
    public static bool ghostTapping;
    public static bool pendolumEnabled;
    public static bool inSong;

    public static void SetGhostTapping(Toggle toggle)
    {
        ghostTapping = toggle.isOn;
    }
}
