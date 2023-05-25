using UnityEngine;

public class RandomEntityColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EntityVisual>().ChangeColor(Stance.GetRandomColor());
    }
}
