using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
public class LaserWeapon : MonoBehaviour
{

    [Tooltip("if this is false, raycasts won't be computed for this laser sight")]
    public bool PerformRaycast = true;

    public bool DrawLaser = true;

    /// the origin of the raycast used to detect obstacles
    [Tooltip("the origin of the raycast used to detect obstacles")]
    public Vector3 RaycastOriginOffset;
    /// the origin of the visible laser
    [Tooltip("the origin of the visible laser")]
    public Vector3 LaserOriginOffset;
    /// the maximum distance to which we should draw the laser
    [Tooltip("the maximum distance to which we should draw the laser")]
    public float LaserMaxDistance = 50;
    /// the collision mask containing all layers that should stop the laser
    [Tooltip("the collision mask containing all layers that should stop the laser")]
    public LayerMask LaserCollisionMask;


    [Header("Prefabs")]
    public GameObject[] beamLineRendererPrefab;
    public GameObject[] beamStartPrefab;
    public GameObject[] beamEndPrefab;

    private int currentBeam = 0;

    private GameObject beamStart;
    private GameObject beamEnd;
    private GameObject beam;
    private LineRenderer line;

    [Header("Adjustable Variables")]
    public float beamEndOffset = 1f; //How far from the raycast hit point the end effect is positioned
    public float textureScrollSpeed = 8f; //How fast the texture scrolls along the beam
    public float textureLengthScale = 3; //Length of the beam texture

    public RaycastHit _hit { get; protected set; }
    public Vector3 _origin { get; protected set; }
    public Vector3 _raycastOrigin { get; protected set; }

    protected Vector3 _destination;
    protected Vector3 _laserOffset;
    protected Weapon _weapon;
    protected Vector3 _direction;

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        beamStart = Instantiate(beamStartPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        beamEnd = Instantiate(beamEndPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        beam = Instantiate(beamLineRendererPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        beamStart.transform.parent = transform;
        beam.transform.parent = transform;
        beamEnd.transform.parent = transform;
        line = beam.GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        ShootLaser();
    }

    /// <summary>
    /// Draws the actual laser
    /// </summary>
    protected virtual void ShootLaser()
    {
        //if (!PerformRaycast)
        {
            //return;
        }

        _laserOffset = LaserOriginOffset;

        if (true)
        {
            // our laser will be shot from the weapon's laser origin
            _origin = MMMaths.RotatePointAroundPivot(this.transform.position + _laserOffset, this.transform.position, this.transform.rotation);
            _raycastOrigin = MMMaths.RotatePointAroundPivot(this.transform.position + RaycastOriginOffset, this.transform.position, this.transform.rotation);

            // we cast a ray in front of the weapon to detect an obstacle
            _hit = MMDebug.Raycast3D(_raycastOrigin, this.transform.forward, LaserMaxDistance, LaserCollisionMask, Color.red, true);


            // if we've hit something, our destination is the raycast hit
            if (_hit.transform != null)
            {
                _destination = _hit.point;
            }
            // otherwise we just draw our laser in front of our weapon 
            else
            {
                _destination = _origin + this.transform.forward * LaserMaxDistance;
            }

            Vector3 tdir = _hit.point - transform.position;
            ShootBeamInDir(transform.position, tdir);
        }
    }
    void ShootBeamInDir(Vector3 start, Vector3 dir)
    {
		line.positionCount = 2;
        line.SetPosition(0, start);
        beamStart.transform.position = start;

        Vector3 end = Vector3.zero;
        RaycastHit hit;
        if (Physics.Raycast(start, dir, out hit))
            end = hit.point - (dir.normalized * beamEndOffset);
        else
            end = transform.position + (dir * 100);

        beamEnd.transform.position = end;
        line.SetPosition(1, end);

        beamStart.transform.LookAt(beamEnd.transform.position);
        beamEnd.transform.LookAt(beamStart.transform.position);

        float distance = Vector3.Distance(start, end);
        line.sharedMaterial.mainTextureScale = new Vector2(distance / textureLengthScale, 1);
        line.sharedMaterial.mainTextureOffset -= new Vector2(Time.deltaTime * textureScrollSpeed, 0);
    }

}
