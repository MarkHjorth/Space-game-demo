using UnityEngine;
using System.Collections;
using System;

public class GameSession : MonoBehaviour {

    public System.DateTime startTime;
    public System.DateTime stopTime;
    public string identifyer;
    public int userID = 0;

    void Start()
    {
        startTime = System.DateTime.Now;
        stopTime = System.DateTime.Now;
        identifyer = Hash128.Parse(userID.ToString() + startTime.ToString() + Input.mousePosition.ToString()).ToString();
    }

    public void SetUserID(int userId)
    {
        this.userID = userId;
    }

    public void Stop()
    {
        stopTime = System.DateTime.Now;
    }
}
