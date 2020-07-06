using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // TODO: CLEAN UP MESSY CODE FROM THE CAMERA PERSPECTIVE CHANGE
public class DimentionShift : MonoBehaviour
{

    [SerializeField] List<GameObject> SwappableObjects; // A list with all the parents of the 2D and 3D objects
    [SerializeField] float ProjectionChangeTime;

	[SerializeField] GameObject player; // The player object

    Camera camera;


    List<GameObject> Objects3D = new List<GameObject>();
    List<GameObject> Objects2D = new List<GameObject>();

    [HideInInspector] public bool currently3D = true;

	bool camera_currently3D = true;
    public bool _changing;
    bool ChangingMode;
    bool ChangeProjection;

    float _currentT;

    #region Methods

    void Start()
    {
		
		DontDestroyOnLoad(this);

        camera = Camera.main;

        foreach (GameObject obj in SwappableObjects)
        {
            Objects3D.Add(obj.transform.GetChild(0).gameObject);
            Objects2D.Add(obj.transform.GetChild(1).gameObject);
        }

        if(currently3D){
            foreach (GameObject obj in Objects2D)
            {
                obj.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !_changing)
            SwitchObjectState();	
            	
        CameraProjectionChange1();

	}

	private void LateUpdate()
    {
        CameraProjectionChange2();
    }


	public void DimentionPosition(GameObject object2d){ // The function that put the player at the given 3D coordinate whilst in 2D space
		for (int i = 0; i < Objects2D.Count; i++)
		{
			if(Objects2D[i] == object2d){ // Check which gameobject it is
				player.transform.GetChild(0).position = Objects3D[i].transform.position + player.transform.GetChild(0).GetComponent<Collider>().bounds.extents; // If object is found, set the position in 3D space
			}
		}
	}

    private void CameraProjectionChange2()
    {
        if (!_changing)
        {
            return;
        }

        var currentlyOrthographic = camera.orthographic;
        Matrix4x4 orthoMat, persMat;
        if (currentlyOrthographic)
        {
            orthoMat = camera.projectionMatrix;

            camera.orthographic = false;
            camera.ResetProjectionMatrix();
            persMat = camera.projectionMatrix;
        }
        else
        {
            persMat = camera.projectionMatrix;

            camera.orthographic = true;
            camera.ResetProjectionMatrix();
            orthoMat = camera.projectionMatrix;
        }
        camera.orthographic = currentlyOrthographic;

        _currentT += (Time.deltaTime / ProjectionChangeTime);
        if (_currentT < 1.0f)
        {
            if (currentlyOrthographic)
            {
                camera.projectionMatrix = MatrixLerp(orthoMat, persMat, _currentT * _currentT);
            }
            else
            {
                camera.projectionMatrix = MatrixLerp(persMat, orthoMat, Mathf.Sqrt(_currentT));
            }
        }
        else
        {
            _changing = false;
            camera.orthographic = !currentlyOrthographic;
            camera.ResetProjectionMatrix();
        }
    }
	private void CameraProjectionChange1(){
		if (Input.GetKeyDown(KeyCode.X) && !_changing)
		{
			ChangingMode = true;
			ChangeProjection = true;
			if (camera_currently3D) 
				camera_currently3D = false;
			else
				camera_currently3D = true;
		}

		if (_changing)
			ChangeProjection = false;
		else if (ChangeProjection){
				_changing = true;
				_currentT = 0.0f;
			}
		}
	private Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float t)
	{
		t = Mathf.Clamp(t, 0.0f, 1.0f);
		var newMatrix = new Matrix4x4();
		newMatrix.SetRow(0, Vector4.Lerp(from.GetRow(0), to.GetRow(0), t));
		newMatrix.SetRow(1, Vector4.Lerp(from.GetRow(1), to.GetRow(1), t));
		newMatrix.SetRow(2, Vector4.Lerp(from.GetRow(2), to.GetRow(2), t));
		newMatrix.SetRow(3, Vector4.Lerp(from.GetRow(3), to.GetRow(3), t));
		return newMatrix;
	}

    private void SwitchObjectState()
    {
        if (currently3D)
        {
            currently3D = false;
            for (int i = 0; i < Objects3D.Count; i++)
            {
                Objects2D[i].SetActive(true);
                Objects2D[i].transform.position = Objects3D[i].transform.position;

                Rigidbody rigidbody3D;
                if(Objects3D[i].TryGetComponent<Rigidbody>(out rigidbody3D)){
                    Objects2D[i].GetComponent<Rigidbody2D>().velocity = rigidbody3D.velocity;
                }

                Objects3D[i].SetActive(false);
            }
        }

        else
        {
            currently3D = true;
            for (int i = 0; i < Objects2D.Count; i++)
            {
                Objects3D[i].SetActive(true);
                Objects3D[i].transform.position = new Vector3(Objects2D[i].transform.position.x, Objects2D[i].transform.position.y, Objects3D[i].transform.position.z);

                Rigidbody2D rigidbody2D;
                if(Objects2D[i].TryGetComponent<Rigidbody2D>(out rigidbody2D)){
                    Objects3D[i].GetComponent<Rigidbody>().velocity = (Vector3)rigidbody2D.velocity;
                }

                Objects2D[i].SetActive(false);

            }
        }
    }

    #endregion
}
