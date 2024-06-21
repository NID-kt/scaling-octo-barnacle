using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObject : MonoBehaviour
{
    public Renderer renderer;

    public bool isTouch = false;

    public BallColor color;

    // Start is called before the first frame update
    void Start()
    {
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch)
        {
            renderer.material.SetColor("_EmissionColor", new Color(0.5f, 0.5f, 0f));
        }
        else
        {
            renderer.material.SetColor("_EmissionColor", new Color(0f, 0f, 0f));
        }
    }

    private void ChangeColor()
    {
        // switch (color)
        // {
        //     case BallColor.Red:
        //         renderer.material.SetColor("_Color", Color.red);
        //         break;
        //     case BallColor.Blue:
        //         renderer.material.SetColor("_Color", Color.blue);
        //         break;
        //     case BallColor.Green:
        //         renderer.material.SetColor("_Color", Color.green);
        //         break;
        //     case BallColor.Purple:
        //         renderer.material.SetColor("_Color", new Color(1, 0, 1));
        //         break;
        //     case BallColor.Bomb:
        //         renderer.material.SetColor("_Color", new Color(0, 0, 0));
        //         break;
        // }
    }

    public void Explosion(GameObject deleteEffect, ScoreManager scoreManager)
    {
        var h = Physics.SphereCastAll(transform.position, 5f, Vector3.forward);
        foreach (var hit in h)
        {
            if (hit.collider.CompareTag("Ball"))
            {
                var deleteObject = Instantiate(deleteEffect);
                deleteObject.transform.position = hit.collider.transform.position;
                Destroy(hit.collider.gameObject);
            }
        }

        scoreManager.AddScore((int)Mathf.Pow(2, h.Length));
    }
}