using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInScript : MonoBehaviour
{
    public Fade fades;
    void Start()
    {
        fades.FadeIn(0.5f, () => print("フェードイン完了"));
        fades.FadeOut(0.5f, () => print("フェードアウト完了"));
    }

 
}
