using UnityEngine;

public class Test : MonoBehaviour
{
    public Fade fades;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            fades.FadeIn(0.5f, () => print("�t�F�[�h�C������"));
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            fades.FadeOut(0.5f, () => print("�t�F�[�h�A�E�g����"));
        }
    }
}