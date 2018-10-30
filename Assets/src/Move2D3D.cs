using UnityEngine;
using System.Collections;

public class Move2D3D : MonoBehaviour
{
    public float NummerofLayers;
    public enum mergeMethod { front,back,center};
    public mergeMethod MethodSwitch;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void MoveTo2D()
    {
        switch(MethodSwitch)
        {
            case mergeMethod.back:
                break;
            case mergeMethod.center:
                break;
            case mergeMethod.front:
                break; 
        }
    }

}
