using UnityEngine;

public class Test : MonoBehaviour
{
    public Fade fades;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            fades.FadeIn(0.5f, () => print("フェードイン完了"));
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            fades.FadeOut(0.5f, () => print("フェードアウト完了"));
        }
    }
}