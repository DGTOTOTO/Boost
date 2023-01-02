using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Debug.Log("we leave game");
            Application.Quit();
        }
    }
}
