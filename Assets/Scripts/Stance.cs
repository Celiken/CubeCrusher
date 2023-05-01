using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class Stance
{
    public enum Type
    {
        Blue = 0,
        Red = 1,
        Green = 2,
        Yellow = 3,
        NUMBER_OF_VALUE = 4
    }

    public static Type GetRandomColor()
    {
        int r = Random.Range(0, (int)Type.NUMBER_OF_VALUE);
        return (Type)r;
    }

    public static Type GetNextColor(Type color)
    {
        switch (color)
        {
            default:
            case Type.Blue:
                return Type.Red;
            case Type.Red:
                return Type.Green;
            case Type.Green:
                return Type.Blue;
            case Type.Yellow:
                return Type.Yellow;
        }
    }

    public static Material GetMaterialForColor(Type color)
    {
        switch (color)
        {
            default:
            case Type.Blue:
                return GameAssets.Instance.blueMat;
            case Type.Red:
                return GameAssets.Instance.redMat;
            case Type.Green:
                return GameAssets.Instance.greenMat;
            case Type.Yellow:
                return GameAssets.Instance.yellowMat;
        }
    }

    public static VertexGradient GetColorGradientForColor(Type color)
    {
        switch (color)
        {
            default:
            case Type.Blue:
                return new VertexGradient(Color.white, Color.white, Color.blue, Color.blue);
            case Type.Red:
                return new VertexGradient(Color.white, Color.white, Color.red, Color.red);
            case Type.Green:
                return new VertexGradient(Color.white, Color.white, Color.green, Color.green);
            case Type.Yellow:
                return new VertexGradient(Color.white, Color.white, Color.yellow, Color.yellow);
        }
    }
}
