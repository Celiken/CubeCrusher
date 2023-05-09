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

    public static Material GetEnemyMaterial(Type color)
    {
        switch (color)
        {
            default:
            case Type.Blue:
                return GameAssets.Instance.blueEnemyMat;
            case Type.Red:
                return GameAssets.Instance.redEnemyMat;
            case Type.Green:
                return GameAssets.Instance.greenEnemyMat;
        }
    }

    public static Material GetPlayerMaterial(Type color)
    {
        switch (color)
        {
            default:
            case Type.Blue:
                return GameAssets.Instance.bluePlayerMat;
            case Type.Red:
                return GameAssets.Instance.redPlayerMat;
            case Type.Green:
                return GameAssets.Instance.greenPlayerMat;
        }
    }

    public static Material GetDamageFont(bool isCrit)
    {
        return isCrit ? GameAssets.Instance.critDamageFont : GameAssets.Instance.damageFont;
    }

    public static VertexGradient GetColorGradientForTextUI(Type color, bool isCrit)
    {
        switch (color)
        {
            default:
            case Type.Blue:
                return isCrit ? GameAssets.Instance.blueCritGradient : GameAssets.Instance.blueGradient;
            case Type.Red:
                return isCrit ? GameAssets.Instance.redCritGradient : GameAssets.Instance.redGradient;
            case Type.Green:
                return isCrit ? GameAssets.Instance.greenCritGradient : GameAssets.Instance.greenGradient;
        }
    }
}
