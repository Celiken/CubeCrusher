using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorType
{
    public enum Color
    {
        Blue = 0,
        Red = 1,
        Green = 2,
        NUMBER_OF_VALUE = 3
    }

    public static Color GetRandomColor()
    {
        int r = Random.Range(0, (int)Color.NUMBER_OF_VALUE);
        return (Color)r;
    }

    public static Color GetNextColor(Color color)
    {
        switch (color)
        {
            case Color.Blue:
                return Color.Red;
            case Color.Red:
                return Color.Green;
            default:
            case Color.Green:
                return Color.Blue;
        }
    }

    public static Material GetMaterialForColor(Color color)
    {
        switch (color)
        {
            default:
            case Color.Blue:
                return GameAssets.Instance.blueMat;
            case Color.Red:
                return GameAssets.Instance.redMat;
            case Color.Green:
                return GameAssets.Instance.greenMat;
        }
    }
}
