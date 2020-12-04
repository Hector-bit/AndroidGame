using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ropeSystem : MonoBehaviour {
    // 1
    public GameObject ropeHingeAnchor;
    public DistanceJoint2D ropeJoint;
    public Transform crosshair;
    public SpriteRenderer crosshairSprite;
    public playerMoveControl playerMovement;
    public bool ropeAttached;
    private Vector2 playerPosition;
    private Rigidbody2D ropeHingeAnchorRb;
    private SpriteRenderer ropeHingeAnchorSprite;
    private bool distanceSet;
    private bool grappleThing;

    //This joystick should control where the grapple will aim
    public Joystick joyStickTwo;

    //Grapple variables for physics
    public LineRenderer ropeRenderer;
    public LayerMask ropeLayerMask;
    private float ropeMaxCastDistance = 20f;
    private List<Vector2> ropePositions = new List<Vector2>();

    //More variables 
    // public Vector2 ropeHook;
    // public float swingForce = 4f;

    // This variable should act as memory for the grapple aim so that is doesn't aim 
    // at its default position
    public float AimMemory;

    void Awake()
    {
        // 2
        ropeJoint.enabled = false;
        grappleThing = false;
        playerPosition = transform.position;
        ropeHingeAnchorRb = ropeHingeAnchor.GetComponent<Rigidbody2D>();
        ropeHingeAnchorSprite = ropeHingeAnchor.GetComponent<SpriteRenderer>();
        AimMemory = 90;
    }

    void Update()
    {
        // 3
        Debug.Log("Horizontal: " + joyStickTwo.Horizontal + "Vertical: " + joyStickTwo.Vertical);
        var worldMousePosition = (new Vector3(joyStickTwo.Horizontal * 50f, joyStickTwo.Vertical * 50f));
        // Debug.Log(worldMousePosition + "WORLDMOUSEPOSITION");
        var facingDirection = worldMousePosition - transform.position;
        var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
        // Debug.Log(aimAngle + "AIMANGLE");
        // Debug.Log(transform.position + "--PLAYER POSITON--" + playerPosition);
        if (aimAngle < 0f)
        {
            aimAngle = Mathf.PI * 2 + aimAngle;
        }
        if (AimMemory != aimAngle)
        {
            AimMemory = aimAngle;
        }
        Debug.Log("Here" + aimAngle);
        Debug.Log("======AIMMEM=======" + AimMemory);
        // Debug.Log(aimAngle + "=========AIMANGLE=======2==========");
        // 4
        var aimDirection = Quaternion.Euler(0, 0, AimMemory * Mathf.Rad2Deg) * Vector2.right;
        // Debug.Log(aimDirection + "AIM DIRECTION BITCHES");
        // 5
        playerPosition = transform.position;

        // 6
        if (!ropeAttached)
        {
            SetCrosshairPosition(AimMemory);
            playerMovement.isSwinging = false;
        }
        else
        {
            playerMovement.isSwinging = true;
            crosshairSprite.enabled = false;
        }

        HandleInput(aimDirection);
        UpdateRopePositions();
    }

    private void SetCrosshairPosition(float AimMemory){
        if(!crosshairSprite.enabled){
            crosshairSprite.enabled = true;
        }

        var x = transform.position.x + 1f * Mathf.Cos(AimMemory);
        var y = transform.position.y + 1f * Mathf.Sin(AimMemory);

        //NOTE: crossHairPosition may be wrong so replace with setCrossHairPosition if so.
        var crossHairPosition = new Vector3(x, y, 0);
        crosshair.transform.position = crossHairPosition;
    }

    public void grappleTrue(){
        if(grappleThing == false)
        {
            grappleThing = true;
        } 
        else
        {
            grappleThing = false;
            ResetRope();
        }
        UpdateRopePositions();
    }

    public void HandleInput(Vector2 aimDirection){
        //left click shoots the grapple
        // Debug.Log("Joystick vertical" + joyStickTwo.Vertical);
        if (grappleThing == true){
            // Debug.Log("LOOK AT ME DADDDDDDDDDD" + ropeAttached + " ||" + ropeRenderer.enabled);
            if(ropeAttached) return;
            ropeRenderer.enabled = true;
            // Debug.Log("left mouse clicked");
            var hit = Physics2D.Raycast(playerPosition, aimDirection, ropeMaxCastDistance, ropeLayerMask);

            if(hit.collider != null) {
                ropeAttached = true;
                Debug.Log("left joystick did the thing");
                if(!ropePositions.Contains(hit.point)){
                    //Jump slightly to distance the player a little from the ground after grappling to something
                    transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2f), ForceMode2D.Impulse);
                    ropePositions.Add(hit.point);
                    ropeJoint.distance = Vector2.Distance(playerPosition, hit.point);
                    ropeJoint.enabled = true;
                    ropeHingeAnchorSprite.enabled = true;
                }
            }

            else{
                ropeRenderer.enabled = false;
                ropeAttached = false;
                ropeJoint.enabled = false;
            }
        }
        //Right click undoes the grapple
        if(Input.GetMouseButton(1)){
            Debug.Log("RIGHT MOUSE CLICKED");
            ResetRope();
        }
    }

    public void ResetRope(){
        ropeJoint.enabled = false;
        ropeAttached = false;
        playerMovement.isSwinging = false;
        ropeRenderer.positionCount = 2;
        ropeRenderer.SetPosition(0, transform.position);
        ropeRenderer.SetPosition(1, transform.position);
        ropePositions.Clear();
        ropeHingeAnchorSprite.enabled = false;
    }

    private void UpdateRopePositions(){
    // 1
    if (!ropeAttached)
    {
        return;
    }

    // 2
    ropeRenderer.positionCount = ropePositions.Count + 1;

    // 3
    for (var i = ropeRenderer.positionCount - 1; i >= 0; i--)
    {
        if (i != ropeRenderer.positionCount - 1) // if not the Last point of line renderer
        {
            ropeRenderer.SetPosition(i, ropePositions[i]);
                
            // 4
            if (i == ropePositions.Count - 1 || ropePositions.Count == 1)
            {
                var ropePosition = ropePositions[ropePositions.Count - 1];
                if (ropePositions.Count == 1)
                {
                    ropeHingeAnchorRb.transform.position = ropePosition;
                    if (!distanceSet)
                    {
                        ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                        distanceSet = true;
                    }
                }
                else
                {
                    ropeHingeAnchorRb.transform.position = ropePosition;
                    if (!distanceSet)
                    {
                        ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                        distanceSet = true;
                    }
                }
            }
            // 5
            else if (i - 1 == ropePositions.IndexOf(ropePositions.Last()))
            {
                var ropePosition = ropePositions.Last();
                ropeHingeAnchorRb.transform.position = ropePosition;
                if (!distanceSet)
                {
                    ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                    distanceSet = true;
                }
            }
        }
        else
        {
            // 6
            ropeRenderer.SetPosition(i, transform.position);
        }
    }
}
};