using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class CartAgent : Agent
{
    public Rigidbody2D PollBody;
    public Transform PollPos;

    public override void AgentReset()
    {
        transform.localPosition = Vector2.zero;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        PollBody.velocity = Vector2.zero;
        PollBody.angularVelocity = 0;
        PollPos.localPosition = new Vector2(0, 3f);
        PollPos.transform.rotation = Quaternion.Euler(0, 0, 0);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    public override void CollectObservations()
    {
        string result = "AngVel: " + Mathf.Clamp(PollBody.angularVelocity / 500f, -1f, 1f).ToString();
        AddVectorObs(Mathf.Clamp(PollBody.angularVelocity / 500f, -1f, 1f));
        result += " / Angle: " + Mathf.Clamp(PollPos.eulerAngles.z / 100f, -1f, 1f).ToString();
        AddVectorObs(Mathf.Clamp(PollPos.eulerAngles.z / 100f, -1f, 1f));
        result += " / CartVel: " + Mathf.Clamp(GetComponent<Rigidbody2D>().velocity.x / 10f, -1f, 1f).ToString();
        AddVectorObs(Mathf.Clamp(GetComponent<Rigidbody2D>().velocity.x / 10f, -1f, 1f));
    }

    public override void AgentAction(float[] vectorAction, string textAction)
    {
        AddReward(0.1f);
        int action = (int)vectorAction[0];
        if (action == 1)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-10f, 0f));
        }
        else if (action == 2)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(10f, 0f));
        }

    }
}
