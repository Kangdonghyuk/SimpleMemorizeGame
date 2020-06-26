using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DefineColor
{
    public static Color[] Colors = {Color.black, Color.blue, Color.cyan,
                            Color.gray, Color.green, Color.red,
                            Color.yellow};
    public static int Length {
        get {
            return Colors.Length;
        }
    }

    public static Color RandomColor {
        get {
            return Colors[Random.Range(0, Length)];
        }
    }

    public static Color RandomColorUnique {
        get {
            Color color = RandomColor;

            while(GetColorState(color) == true)
                color = RandomColor;

            SetColorState(color);

            return color;
        }
    }

    public static bool[] ColorUsed = new bool[Length];

    public static void ColorStateInitialize() {
        for(int i=0; i<Length; i++)
            ColorUsed[i] = false;
    }
    public static bool GetColorState(Color color) {
        return ColorUsed[IndexOfColors(color)];
    }
    public static void SetColorState(Color color, bool state = true) {
        ColorUsed[IndexOfColors(color)] = state;
    }

    public static int IndexOfColors(Color color) {
        for(int i=0; i<Length; i++) {
            if(Colors[i] == color)
                return i;
        }
        return -1;
    }
}
