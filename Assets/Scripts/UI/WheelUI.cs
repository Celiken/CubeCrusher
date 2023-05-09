using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WheelUI : MonoBehaviour
{
    private int KBM_Index = 0;
    private int Gamepad_Index = 1;

    [SerializeField] private Transform blueUI;
    [SerializeField] private Transform redUI;
    [SerializeField] private Transform greenUI;

    [SerializeField] private Transform topFixPoint;
    [SerializeField] private Transform rightFixPoint;
    [SerializeField] private Transform leftFixPoint;

    [SerializeField] private TextMeshProUGUI nextBinding;
    [SerializeField] private TextMeshProUGUI prevBinding;

    private void Start()
    {
        Player.Instance.OnSwapVisualUpdate += Player_OnSwapVisualUpdate;
        GameInput.Instance.OnDeviceChanged += GameInput_OnDeviceChanged; 
    }

    private void GameInput_OnDeviceChanged(object sender, System.EventArgs e)
    {
        bool isGamepad = GameInput.Instance.IsGamepad();
        nextBinding.text = isGamepad ? GameInput.Instance.inputActions.Player.SwapNext.bindings[Gamepad_Index].ToDisplayString() : GameInput.Instance.inputActions.Player.SwapNext.bindings[KBM_Index].ToDisplayString();
        prevBinding.text = isGamepad ? GameInput.Instance.inputActions.Player.SwapPrev.bindings[Gamepad_Index].ToDisplayString() : GameInput.Instance.inputActions.Player.SwapPrev.bindings[KBM_Index].ToDisplayString();
    }

    private void Player_OnSwapVisualUpdate(object sender, Player.VisualUpdateArgs e)
    {
        RotateWheel(e.newStance);
    }

    private void RotateWheel(Stance.Type newStance)
    {
        switch (newStance)
        {
            case Stance.Type.Blue:
                blueUI.DOMove(topFixPoint.position, 0.2f);
                blueUI.DOScale(topFixPoint.localScale, 0.2f);
                redUI.DOMove(rightFixPoint.position, 0.2f);
                redUI.DOScale(rightFixPoint.localScale, 0.2f);
                greenUI.DOMove(leftFixPoint.position, 0.2f);
                greenUI.DOScale(leftFixPoint.localScale, 0.2f);
                break;
            case Stance.Type.Red:
                redUI.DOMove(topFixPoint.position, 0.2f);
                redUI.DOScale(topFixPoint.localScale, 0.2f);
                greenUI.DOMove(rightFixPoint.position, 0.2f);
                greenUI.DOScale(rightFixPoint.localScale, 0.2f);
                blueUI.DOMove(leftFixPoint.position, 0.2f);
                blueUI.DOScale(leftFixPoint.localScale, 0.2f);
                break;
            case Stance.Type.Green:
                greenUI.DOMove(topFixPoint.position, 0.2f);
                greenUI.DOScale(topFixPoint.localScale, 0.2f);
                blueUI.DOMove(rightFixPoint.position, 0.2f);
                blueUI.DOScale(rightFixPoint.localScale, 0.2f);
                redUI.DOMove(leftFixPoint.position, 0.2f);
                redUI.DOScale(leftFixPoint.localScale, 0.2f);
                break;
        }
    }
}
