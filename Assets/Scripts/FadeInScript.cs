using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScript : MonoBehaviour
{
    public Fade fades;
    void Start()
    {
        fades.FadeIn(0.5f, () => print("�t�F�[�h�C������"));
        fades.FadeOut(0.5f, () => print("�t�F�[�h�A�E�g����"));
    }

 
}
