using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] List<GameObject> touchBallList = new();

    public GameObject deleteEffectObj;
    public ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            touchBallList.Clear();
            var ray = Camera.main!.ScreenPointToRay(mousePosition);
            var h = Physics.RaycastAll(ray, 100f);
            if (h.Length > 0)
            {
                var obj = h[0].collider.gameObject;
                var ball = obj.GetComponent<BallObject>();
                if (obj.CompareTag("Ball") && ball is { isTouch: false })
                {
                    if (ball.color == BallColor.Bomb)
                    {
                        ball.Explosion(deleteEffectObj, scoreManager);
                    }
                    else
                    {
                        ball.isTouch = true;
                        touchBallList.Add(obj);
                        // ball.renderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 0, 0.5f));
                    }
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (touchBallList.Count != 0)
            {
                var first = touchBallList[0];
                var firstColor = first.GetComponent<BallObject>().color;

                var ray = Camera.main!.ScreenPointToRay(mousePosition);
                var h = Physics.RaycastAll(ray, 100f);
                if (h.Length > 0)
                {
                    var obj = h[0].collider.gameObject;
                    var ball = obj.GetComponent<BallObject>();
                    if (obj.CompareTag("Ball"))
                    {
                        if (ball is { isTouch: false }
                            && ball.color == firstColor)
                        {
                            ball.isTouch = true;
                            ball.renderer.material.SetColor("_EmissionColor", new Color(1f, 1f, 0, 0.5f));
                            touchBallList.Add(obj);
                        }
                        else if (ball.color != firstColor)
                        {
                            ReleaseObject();
                        }
                    }
                }
                else
                {
                    ReleaseObject();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            ReleaseObject();
        }
    }

    private void ReleaseObject()
    {
        var count = touchBallList.Count;
        foreach (var obj in touchBallList)
        {
            obj.GetComponent<BallObject>().isTouch = false;
            if (count >= 3)
            {
                var deleteObject = Instantiate(deleteEffectObj);
                deleteObject.transform.position = obj.transform.position;
                Destroy(obj);
            }
        }

        touchBallList.Clear();

        if (count >= 3)
        {
            scoreManager.AddScore((int)Mathf.Pow(2, count));
        }
    }
}