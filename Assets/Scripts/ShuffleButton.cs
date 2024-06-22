using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShuffleButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void ShuffleButtonClicked()
    {
        var objects = FindObjectsByType<BallObject>(FindObjectsSortMode.None);
        foreach (var obj in objects)
        {
            obj.GetComponent<Rigidbody>()
                .AddForce(Quaternion.Euler(0, 0, Random.Range(-90f, 90f)) * Vector3.up * 10f, ForceMode.Impulse);
        }
    }
}