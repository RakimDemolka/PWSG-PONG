using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    Vector3 velocityBeforePowerUp;
    public void SpeedUpBall(BallController p_ballController)
    {
        p_ballController.rb2D.velocity *= 1.5f;
    }
   
}
