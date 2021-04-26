using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    private Animator animator;
    public bool MainCamera = true;
    private void Awake()
    {
        animator = GetComponent<Animator>(); // Загрузка анимации
    }

    // Start is called before the first frame update
    void Update()
    {
        if ((Input.touchCount > 0) && (Input.touches[0].phase == TouchPhase.Began))              //Нажатие на экран
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);            //Испускается луч в объект куда нажали
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))                                   //Если сталкивается с объектом и расстояние меньше 9
            {
                if (hit.transform.tag == "TransformCamera")                                     //Если на объекте висит определенный тег
                {
                    SwitchState();                                                              //Вызов функции по смене камеры
                }
            }
        }
    }
    public void SwitchState()
    {
        if (MainCamera)
        {
            animator.Play("TransitionCamera");    //Загрузка боковой лавки
        }
        else
        {
            animator.Play("MainCamera");          //Загрузка главной камеры
        }

        MainCamera =! MainCamera;
    }

}
