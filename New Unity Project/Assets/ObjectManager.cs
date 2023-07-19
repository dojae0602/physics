using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    public Slider left_MassSlider , right_MassSlider , left_DragSlider , right_DragSlider;
    public float leftget_Drag, rightget_Drag, leftget_Mass, rightget_Mass, leftvelocity_x , leftvelocity_y ,rightvelocity_x , rightvelocity_y;
    public GameObject obj , grid , floor;
    public Rigidbody left_rigidbody , right_rigidbody;
    public Text leftDrag , rightDrag ,leftmass , leftvelocity_xtext , leftvelocity_ytext , rightmass ,rightvelocity_xtext , rightvelocity_ytext;
    public bool isactive = true;
    public bool isactivefloor = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftget_Mass = left_MassSlider.value;
        rightget_Mass = right_MassSlider.value;

        leftget_Drag = left_DragSlider.value;
        rightget_Drag = right_DragSlider.value;

        leftvelocity_x = left_rigidbody.velocity.x;
        leftvelocity_y = left_rigidbody.velocity.y;

        leftvelocity_xtext.text = "x 속도 : " + 10*(Mathf.Floor(leftvelocity_x * 1000f) / 1000f );
        leftvelocity_ytext.text = "y 속도 : " + 10*(Mathf.Floor(leftvelocity_y * 1000f) / 1000f);

        rightvelocity_x = (right_rigidbody.velocity.x);
        rightvelocity_y = right_rigidbody.velocity.y;
        rightvelocity_xtext.text = "x 속도 : " + 10 * (Mathf.Floor(rightvelocity_x * 1000f) / 1000f);
        rightvelocity_ytext.text = "y 속도 : " + 10 * (Mathf.Floor(rightvelocity_y * 1000f) / 1000f);
    }
    public void gridCreate()
    {
        if (isactive == true){
            grid.SetActive(false);
            isactive = false;
        }

        else if (isactive == false)
        {
            grid.SetActive(true);
            isactive = true;
        }
    }

    public void floorCreate()
    {
        if (isactivefloor == true)
        {
            floor.SetActive(false);
            isactivefloor = false;
        }

        else if (isactivefloor == false)
        {
            floor.SetActive(true);
            isactivefloor = true;
        }
    }

    public void leftCreate()
    {
        GameObject newsphere =Instantiate(obj, new Vector3(-8, 6, 0), Quaternion.identity);
        newsphere.GetComponent<Rigidbody>().mass = leftget_Mass;
        newsphere.GetComponent<Rigidbody>().drag = leftget_Drag;
        leftmass.text = "질량(g) : " + 10 * (Mathf.Floor(leftget_Mass * 1000f) / 1000f);
        leftDrag.text = "공기저항 : " + (Mathf.Floor(leftget_Drag * 1000f) / 1000f);
        left_rigidbody = newsphere.GetComponent<Rigidbody>();

    }

    public void rightCreate()
    {
        GameObject newsphere = Instantiate(obj, new Vector3(9, 6, 0), Quaternion.identity);
        newsphere.GetComponent<Rigidbody>().mass = rightget_Mass;
        newsphere.GetComponent<Rigidbody>().drag =  rightget_Drag;
        rightmass.text = "질량(g) : " + 10 * (Mathf.Floor(rightget_Mass * 1000f) / 1000f);
        rightDrag.text = "공기저항 : " + (Mathf.Floor(rightget_Drag * 1000f) / 1000f);
        right_rigidbody = newsphere.GetComponent<Rigidbody>();
    }
}
