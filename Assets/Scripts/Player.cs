using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool isDead = false; // проигрыш
    private bool finish = false; // победа
    private Rigidbody rb; // Объявление новой переменной Rigidbody
    private float speed = 1f; // Скорость движения объекта
    private float maxSpeed = 10f; // максимальная скорость
    private Vector3 previus; // переменная для дебага положения

    // канвасы
    public GameObject toL;
    public GameObject from;
    public GameObject toW;

    //проверка столкновений
    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "DangerObject")
        {
            isDead = true;

        }
        if (col.gameObject.tag == "Finish")
        {
            finish = true;
            Debug.Log("finish true");
        }

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Получение доступа к Rigidbody
    }

    void Update()
    {
        RaycastHit hit; // Создаем луч 
        previus = rb.velocity; // Переменная для дебага

        // Управление для акселерометра
        if (Input.acceleration.y != 0)
            rb.velocity += new Vector3(0, 0, Input.acceleration.y);
        if (Input.acceleration.x != 0)
            rb.velocity += new Vector3(Input.acceleration.x, 0, 0);
        if (Input.acceleration.z >= 11 && Physics.Raycast(transform.position, Vector3.down, out hit, 1f) && hit.transform.gameObject.tag == "Ground")
            rb.velocity += new Vector3(0, 10f, 0);

        // Управление для клавиатуры c ограничением
        if (Input.GetKey(KeyCode.W) && (rb.velocity.z < maxSpeed))
            rb.velocity += new Vector3(0, 0, speed);
        if (Input.GetKey(KeyCode.A) && (rb.velocity.x > -maxSpeed))
            rb.velocity += new Vector3(-speed, 0, 0);
        if (Input.GetKey(KeyCode.D) && (rb.velocity.x < maxSpeed))
            rb.velocity += new Vector3(speed, 0, 0);
        if (Input.GetKey(KeyCode.S) && (rb.velocity.z > -maxSpeed))
            rb.velocity += new Vector3(0, 0, -speed);
        // Прыжок
        if (Input.GetKeyUp(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, out hit, 1f) && hit.transform.gameObject.tag == "Ground")
            rb.velocity += new Vector3(0, 10f, 0);

        // проверка проигрыша
        if (isDead)
        { 
            from.SetActive(false);
        toL.SetActive(true);
        Time.timeScale = 0;
        }
        // проверка победы
        if (finish)
        {
            from.SetActive(false);
            toW.SetActive(true);
            Time.timeScale = 0;
        }

        // дебаг передвижения
        Debug.Log(previus);
    }
}

