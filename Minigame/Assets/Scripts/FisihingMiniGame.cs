using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisihingMiniGame : MonoBehaviour
{
    [Header("Pivot")]
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [Header("Fish")]
    [SerializeField] Transform fish;
    [SerializeField] float timerMultiplicator = 3f;
    [SerializeField] float smoothMotion = 1f;

    [Header("Fish - No tocar")]
    [SerializeField] float fishPosition;
    [SerializeField] float fishDestination;
    [SerializeField] float fishTimer;
    [SerializeField] float fishSpeed;    

    [Header("Hook")]
    [SerializeField] Transform hook;
    [SerializeField] float hookPosition;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 5f;
    [SerializeField] float hookProgress;
    [SerializeField] float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradationPower = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fish();
        Hook();
    }

    void Hook()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("click");
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }

        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;
        hookPosition = Mathf.Clamp(hookPosition, hookSize/2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);
    }

    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timerMultiplicator;

            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);
    }
}
