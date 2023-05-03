using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class Stance
{
    public enum Type
    {
        Blue,
        Red,
        Green,
        NUMBER_OF_VALUE
    }

    public static Type GetRandomColor()
    {
        int r = Random.Range(0, (int)Type.NUMBER_OF_VALUE);
        return (Type)r;
    }

    public static Type GetNextColor(Type color, int dir)
    {
        int newColorVal = (int)color + dir;
        if (newColorVal < 0) newColorVal = (int)Type.NUMBER_OF_VALUE - 1;
        if (newColorVal >= (int)Type.NUMBER_OF_VALUE) newColorVal = 0;
        return (Type)newColorVal;
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
        }
    }
}