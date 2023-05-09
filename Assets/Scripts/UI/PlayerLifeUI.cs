
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeUI : MonoBehaviour
{
    [SerializeField] private Image hpBar;

    [SerializeField] private LifeStat lifeController;

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = lifeController.GetHPRemaining() / (float)lifeController.GetMaxHP();
    }
}
