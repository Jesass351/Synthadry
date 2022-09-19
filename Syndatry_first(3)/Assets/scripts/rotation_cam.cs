using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_cam : MonoBehaviour
{
    public FixedJoystick joystick;
    protected float CameraAngleSpeed = 0.3f;
    protected float CameraAngle;
    public Transform target;
    private Vector3 _local;
    private float _mxd;
    public LayerMask obstacles;
    //public Camera cam;
    // Start is called before the first frame update
    private Vector3 _position
    {
        get { return Camera.main.transform.position; }
        set { Camera.main.transform.position = value; }
    }
    void Start()
    {
        _local = target.InverseTransformPoint(_position);
        _mxd = Vector3.Distance(_position, target.position);
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        CameraAngle += joystick.Horizontal * CameraAngleSpeed;
        //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, 
            //transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 20, 30), 0.6f);
        Camera.main.transform.position = transform.position +
            Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 20, 30);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);
        ObReact();

    }
    
    void ObReact()
    {
        var distance = Vector3.Distance(_position, target.position);
        RaycastHit hit;
        if (Physics.Raycast(target.position ,Camera.main.transform.position - target.position, 
            out hit, _mxd, obstacles))
        {
            _position = hit.point;
        }
        else if (distance < _mxd && !Physics.Raycast(_position, -transform.forward, .1f, obstacles))
        {
            //_position = Vector3.Lerp(Camera.main.transform.position,
            //transform.position + Quaternion.AngleAxis(CameraAngle, Vector3.up) * new Vector3(0, 20, 30), 0.01f);
            _position -= Camera.main.transform.forward * .05f;
        }
    }
}
