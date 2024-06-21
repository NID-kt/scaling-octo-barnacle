using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    // public GameObject ballObj;
    public List<GameObject> balls;

    private int count = 0;
    private int generateCount = 0;
    const int MAX_COUNT = 30;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        count %= MAX_COUNT;
        if (count == 0)
        {
            generateCount++;
            generateCount %= 10;

            var ball = balls[Random.Range(0, balls.Count)];
            var gameObject = Instantiate(ball, transform);
            // gameObject.transform.parent = this.transform;
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.GetComponent<Rigidbody>()
                .AddForce(Quaternion.Euler(0, 0, Random.Range(-60f, 60f)) * Vector3.down * 10f, ForceMode.Impulse);

            // if (generateCount == 0)
            // {
            //     gameObject.GetComponent<BallObject>().color = BallColor.Bomb;
            // }
            // else
            // {
            //     gameObject.GetComponent<BallObject>().color = (BallColor)Random.Range(0, 4);
            // }
        }
    }
}