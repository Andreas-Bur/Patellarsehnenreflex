using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour
{

    Vector3 middlePoint;        //drag
    Vector3 oldMiddlePoint;     //drag
    Vector3 newMouseLocation;   //rotate

    float scrollSensitivity;    //scroll
    float rotateSensitivity;    //rotate
    float angleX, angleY;       //rotate

    private Vector3 screenPointMiddle;
    private Vector3 offsetMiddle;
    private Vector3 dragDifference;

    private bool isRotating, isDragging;

    public static Camera mainCam;
    public static Camera boneCam;
    public static Camera nerveCam;
    public static Camera rueckenmarkCam;

    public static bool disableMovement = false;

    void Start()
    {
        scrollSensitivity = 40;
        rotateSensitivity = 150;

        angleX = 0;
        angleY = 0;

        middlePoint = Vector3.zero;
        oldMiddlePoint = middlePoint;

        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        boneCam = GameObject.Find("Bone Camera").GetComponent<Camera>();
        nerveCam = GameObject.Find("Nerven Camera").GetComponent<Camera>();
        rueckenmarkCam = GameObject.Find("Rueckenmark Camera").GetComponent<Camera>();

    }

    void Update()
    {

        updateStatus();

        if (isDragging && !disableMovement)
        {

            if (Input.GetMouseButtonDown(1))
            {

                screenPointMiddle = mainCam.WorldToScreenPoint(middlePoint);
                offsetMiddle = -middlePoint - mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPointMiddle.z));

            }

            if (Input.GetMouseButton(1))
            {

                Vector3 cursorPointMiddle = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPointMiddle.z);
                Vector3 cursorPositionMiddle = mainCam.ScreenToWorldPoint(cursorPointMiddle) + offsetMiddle;

                middlePoint = -cursorPositionMiddle;

                mainCam.transform.position += (middlePoint - oldMiddlePoint);
                boneCam.transform.position += (middlePoint - oldMiddlePoint);
                nerveCam.transform.position += (middlePoint - oldMiddlePoint);

                screenPointMiddle = mainCam.WorldToScreenPoint(middlePoint);
                offsetMiddle = -middlePoint - mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPointMiddle.z));
                oldMiddlePoint = middlePoint;
            }

        }
        else if (isRotating && !disableMovement)
        {
            newMouseLocation = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            angleX = newMouseLocation.x * 360 / (2 * Mathf.PI * Vector3.Distance(transform.position, middlePoint) * Time.deltaTime * rotateSensitivity);
            angleY = newMouseLocation.y * 360 / (2 * Mathf.PI * Vector3.Distance(transform.position, middlePoint) * Time.deltaTime * rotateSensitivity);
            mainCam.transform.RotateAround(middlePoint, Vector3.up, angleX);
            mainCam.transform.RotateAround(middlePoint, -transform.right, angleY);

            boneCam.transform.RotateAround(middlePoint, Vector3.up, angleX);
            boneCam.transform.RotateAround(middlePoint, -transform.right, angleY);

            nerveCam.transform.RotateAround(middlePoint, Vector3.up, angleX);
            nerveCam.transform.RotateAround(middlePoint, -transform.right, angleY);
        }

        else if (Input.GetAxis("Mouse ScrollWheel") != 0 && !disableMovement)
        {

            Vector3 next_position;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                next_position = mainCam.transform.position + mainCam.transform.forward * scrollSensitivity * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 3;
            }
            else
            {
                next_position = mainCam.transform.position + mainCam.transform.forward * scrollSensitivity * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;
            }

            mainCam.transform.position = next_position;
            boneCam.transform.position = next_position;
            nerveCam.transform.position = next_position;

        }

    }

    void updateStatus()
    {
        if (!disableMovement)
        {
            //remove
            if (isDragging && (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetMouseButtonUp(1)))
            {
                isDragging = false;
            }

            if (isRotating && Input.GetMouseButtonUp(1))
            {
                isRotating = false;
            }


            //add
            if (!isRotating && (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(1)))
            {
                isDragging = true;
            }

            if (!isDragging && Input.GetMouseButtonDown(1))
            {
                isRotating = true;
            }
        }else
        {
            isDragging = false;
            isRotating = false;
            
        }
        
    }

    Vector3 MousePos()
    {
        return mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCam.nearClipPlane));
    }

}
