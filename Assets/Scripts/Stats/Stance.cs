using TMPro;
using UnityEngine;

public static class Stance
{
    public enum Type
    {
        Blue,
        Red,
        Green,
        Undefined,
    }

    public static Type GetRandomColor()
    {
        int r = Random.Range(0, (int)Type.Undefined);
        return (Type)r;
    }

    public static Type GetNextColor(Type color, int dir)
    {
        int newColorVal = (int)color + dir;
        if (newColorVal < 0) newColorVal = (int)Type.Undefined - 1;
        if (newColorVal >= (int)Type.Undefined) newColorVal = 0;
        return (Type)newColorVal;
    }

    public static Color GetColor(Type color)
    {
        switch (color)
        {
            default:
            case Type.Blue:
                return Color.blue;
            case Type.Red:
                return Color.red;
            case Type.Green:
                return Color.green;
            case Type.Undefined:
                return Color.white;
        }
    }

    public static VertexGradient GetColorGradientForTextUI(Type stance)
    {
        Color color = GetColor(stance);
        return new VertexGradient(color);
    }
}
