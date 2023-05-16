using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FadeFireflies : MonoBehaviour
{
    public VisualEffect fireflies;
    public void Fading()
    {
        fireflies.Stop();
    }
}
