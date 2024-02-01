using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanets : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    private float timer = 0.0f;
    private Vector3 initialScale;
    private Vector3 initialRotation;
    [SerializeField]
    GameObject planet;
    void Start()
    {
        initialRotation = planet.transform.eulerAngles;
        initialScale = planet.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            timer = 0.0f;
            score = 0;
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                planet.transform.Rotate(0, -touch.deltaPosition.x, 0);
                planet.transform.Rotate(touch.deltaPosition.y, 0, 0);
            }
        }
        else if (Input.touchCount == 2)
        {
            timer = 0.0f;
            score = 0;
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);
            if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
            {
                Vector2 touch1PrevPos = touch1.position - touch1.deltaPosition;
                Vector2 touch2PrevPos = touch2.position - touch2.deltaPosition;
                float prevTouchDeltaMag = (touch1PrevPos - touch2PrevPos).magnitude;
                float touchDeltaMag = (touch1.position - touch2.position).magnitude;
                float deltaMagDiff = prevTouchDeltaMag - touchDeltaMag;
                planet.transform.localScale += new Vector3(1, 1, 1) * deltaMagDiff * Time.deltaTime;
            }
        }
        else if (Input.touchCount == 0)
        {

            timer += Time.deltaTime;
            score = (int)timer % 60;
            if (score > 10)
            {
                planet.transform.eulerAngles = initialRotation;
                planet.transform.localScale = initialScale;
            }
        }
    }
}
