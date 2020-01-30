using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parameters
    [SerializeField] float minX = 1f; // left limit
    [SerializeField] float MaxX = 15f; // right limit <- check the coordinate of paddle on the editor
    [SerializeField] float screenWidthInUnits = 16f;

    // cached references
    GameSession theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>(); // when start the game, the references are stored in variables
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update() // we want to know each frame when the paddle moves
    {
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnits); // console shows the coordinates of mouse position
        //float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y); // coordinate of paddle position <- go to the position of (x, y)
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, MaxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x; // find the ball position and make paddle follow it automatically
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
