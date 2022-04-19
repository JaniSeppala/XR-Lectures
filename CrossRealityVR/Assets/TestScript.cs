using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Color originalColor;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        originalColor = material.color;
    }

    public void TurnRed()
    {
        material.color = new Color(1f, 0f, 0f);
    }

    public void TurnBlue()
    {
        material.color = new Color(0f, 0f, 1f);
    }

    public void TurnGreen()
    {
        material.color = new Color(0f, 1f, 0f);
    }

    public void RevertToOriginalColor()
    {
        material.color = originalColor;
    }
}
