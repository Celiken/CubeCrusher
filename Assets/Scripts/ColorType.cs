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
        Yellow = 3,
        NUMBER_OF_VALUE = 4
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
            default:
            case Color.Blue:
                return Color.Red;
            case Color.Red:
                return Color.Green;
            case Color.Green:
                return Color.Blue;
            case Color.Yellow:
                return Color.Yellow;
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
            case Color.Yellow:
                return GameAssets.Instance.yellowMat;
        }
    }
}
