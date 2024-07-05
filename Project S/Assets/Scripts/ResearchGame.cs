using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchGame : MonoBehaviour
{
    // Unity Gameobject
    public GameObject ship;
    public GameObject target;
    public bool leftControl;
    public bool rightControl;


    // Parameters
    public int shipDistance = 3;

    // Note:  1 PI-radian = 180 Degrees

    // Game settings

    private float researchPointsPerSecond = 1; 
    // How many points are gained per second while the target is in range

    private float targetSize = 0.1f; 
    // The size in PI-radians of the target (does not affect visuals)

    private float shipSpeed = 0.5f; 
    // Speed in PI-radians per second

    
    // Operational Variables

    private int shipMoveDirection = 0;
    // What direction the ship moves in (1 clockwise, 0 still, -1 counter-clockwise)

    private int targetMoveDirection = 0;
    // What direction the target moves in (1 clockwise, 0 still, -1 counter-clockwise)

    private float shipPosition = 0f;
    // The position in PI-radians of the ship

    private float targetSpeed; 
    // The speed the target moves at (set randomly)

    private float targetTimer = 0f; 
    // The timer until the target swaps stationary/moving states (set randomly)

    private float targetPosition;
    // Position in PI-radians of the target

    private float targetDistance = 0;
    // Distance from centre of the target

    private int targetState;
    // The state the target is in with integer pseudo-enumerations

    private int state_IDLE = 0;
    // Assigned integer of idle state

    private int state_MOVING = 1;
    // Assigned integer of moving state 


    private float researchScore = 0;
    // The score output, starts at zero

   public GameObject player;
   public GameObject Environment;

   public bool flag;


    // Start is called before the first frame update
    void Start()
    {
        targetState = state_IDLE; // Target begins in idle state
        targetPosition = Random.Range(0f, 2f); // Target begins in random position around circle
        targetTimer = Random.Range(2f,4f); // Target has random time (seconds) before it begins moving
        targetDistance = 1;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        // get canmove from script
        player.TryGetComponent<PlayerController>(out var component);
        if (component.canMove == false){
        ActualGame();
        flag = false;
        Environment.TryGetComponent<EnvironmentHandler>(out var newVar);
        newVar.Research = researchScore;
        }else{
            if (flag == false){
                // submit research score

                // reset score.
                flag = true;
            }
        }
    }

    void ActualGame(){
        leftControl = Input.GetKey(KeyCode.LeftArrow); // Left control currently set to keyboard input (left arrow)
        rightControl = Input.GetKey(KeyCode.RightArrow); // Right control currently set to keyboard input (right arrow)
        shipMoveDirection = 0; // Default direction if no controls are provided
        
        if (leftControl)
        {
            shipMoveDirection -= -1;
            // Offset the move direction in the negative if the left control is active
        } 
        if (rightControl)
        {
            shipMoveDirection += -1;
            // Offset the move direciton in the positive if the right control is active
        }

        shipPosition += shipMoveDirection * shipSpeed * Time.deltaTime;
        // Apply the offset relative to the speed parameter and the real timescale

        targetTimer -= Time.deltaTime; // Subtract the time passed from the timer (seconds)

        if (targetTimer <= 0) // Swap states condition
        {
            if (targetState == state_IDLE) // Idle swap case
            {
                targetState = state_MOVING; 
                targetTimer = Random.Range(1f,4f); // Can be modified
                targetSpeed = Random.Range(0.1f, 1f); // Can be modified (speed is PI-radians per second)

                if ((Random.Range(0f, 1f) > 0.5)) // 50% chance of being true
                {
                    targetMoveDirection = 1; // Clockwise
                } else
                {
                    targetMoveDirection = -1; // Counter-clockwise
                }
           
            } else if (targetState == state_MOVING)
            {
                targetState = state_IDLE;
                targetTimer = Random.Range(2.5f,4.0f); // Can be modified
                targetMoveDirection = 0; // Cannot move while direction set to zero
            }
        }

        targetPosition += targetSpeed * targetMoveDirection * Time.deltaTime;
        // Update target position relative to direction, speed and real time 

        
        // Set the position via trigonometric function relative to the shipDistance parameter
        ship.transform.localPosition = new Vector3(
               shipDistance * -Mathf.Sin((float)shipPosition * Mathf.PI), 
               shipDistance * Mathf.Cos((float)shipPosition * Mathf.PI), 
               0f // Z-axis irrelevant
               );

        // Set the rotation of the ship to face centre
        ship.transform.localRotation = Quaternion.Euler(0, 0,  180 * (float)shipPosition);


        target.transform.localPosition = new Vector3(
            targetDistance * -Mathf.Sin((float)targetPosition * Mathf.PI), 
            targetDistance * Mathf.Cos((float)targetPosition * Mathf.PI), 
            0f // Z-axis irrelevant
            );
        
        // Set rotation of target to perpendicular to centre
        target.transform.localRotation = Quaternion.Euler(0, 0,180 * (float)targetPosition);

        // Wrap-around logic; ensure positions stay between 0 and 2
        while (targetPosition > 2)
        {
            targetPosition -= 2;
        }
        while (targetPosition < 0)
        {
            targetPosition += 2;
        }
        while (shipPosition>2)
        {
            shipPosition -= 2;
        }
        while (shipPosition < 0)
        {
            shipPosition += 2;
        }

        // Wrap-around proximity detection
        float linearProximity = Mathf.Abs(targetPosition - shipPosition);
        float wrappedProximity = 2 - linearProximity;
        float closestProximity = Mathf.Min(linearProximity, wrappedProximity);

        // Add to score if proximity within the target size
        if (closestProximity <= targetSize)
        {
            researchScore += researchPointsPerSecond * Time.deltaTime;
        }
    }

    public float getScore(){
        return researchScore;
    }
}
