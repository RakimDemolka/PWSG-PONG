using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPcos : MonoBehaviour
{
    Vector3 localScaleBeforePowerUp;
    public void SizeUp(BallController p_ballController)
    {
        localScaleBeforePowerUp = Vector3.one * .3f;
        p_ballController.transform.localScale *= 1.5f;
        StopAllCoroutines();
        StartCoroutine(routine:SpeedUpBallCoroutine(p_ballController:p_ballController));
    }
    private IEnumerator SpeedUpBallCoroutine(BallController p_ballController)
    {
        yield return new WaitForSeconds(seconds: 2f);
        p_ballController.transform.localScale = localScaleBeforePowerUp;
    }
}

