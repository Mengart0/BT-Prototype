using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placeholder : MonoBehaviour
{
    Color lerpedColor = Color.white;

    Image enemyCube;

    private void Start()
    {
        enemyCube = GameObject.Find("FGT - Enemy").GetComponent<Image>();
    }

    void Update()
    {
        lerpedColor = Color.Lerp(Color.white, Color.black, 100000);

        enemyCube.color = lerpedColor;
    }

    IEnumerator lerpIt()
    {




        return null;
    }

}
