using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewChanger : MonoBehaviour
{
    public float changePerspectiveTime = 5f;
    private Camera camera;
    private Matrix4x4 ortho,
                        perspective;
    public float fov = 60f,
                        near = .3f,
                        far = 1000f,
                        orthographicSize = 50f;
    private float aspect;
    //private MatrixBlender blender;
    private bool orthoOn;
    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
        aspect = (float)Screen.width / (float)Screen.height;
        ortho = Matrix4x4.Ortho(-orthographicSize * aspect, orthographicSize * aspect, -orthographicSize, orthographicSize, near, far);
        perspective = Matrix4x4.Perspective(fov, aspect, near, far);
        camera.projectionMatrix = ortho;
        orthoOn = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space))
        {
            ChangeView();
        }
	}

    private void ChangeView()
    {
        orthoOn = !orthoOn;
        if(orthoOn)
        {
            BlendToMatrix(ortho, changePerspectiveTime);
        }
        else
        {
            BlendToMatrix(perspective, changePerspectiveTime);
        }
    }


    //lerps transition between ortho and perspective view
    public static Matrix4x4 MatrixLerp(Matrix4x4 from, Matrix4x4 to, float time)
    {
        Matrix4x4 ret = new Matrix4x4();
        for (int i = 0; i < 16; i++)
            ret[i] = Mathf.Lerp(from[i], to[i], time);
        return ret;
    }

    private IEnumerator LerpFromTo(Matrix4x4 src, Matrix4x4 dest, float duration)
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            camera.projectionMatrix = MatrixLerp(src, dest, (Time.time - startTime) / duration);
            yield return 1;
        }
        camera.projectionMatrix = dest;
    }

    public Coroutine BlendToMatrix(Matrix4x4 targetMatrix, float duration)
    {
        StopAllCoroutines();
        return StartCoroutine(LerpFromTo(camera.projectionMatrix, targetMatrix, duration));
    }
}
