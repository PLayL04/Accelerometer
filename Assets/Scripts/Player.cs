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
    private float maxSpeed = 8f; // максимальная скорость
    private Vector3 previus; // переменная для дебага положения
    public Transform camPos;
    public Transform ggPos;
    public float magic;
    public float jump;

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
        if (Input.acceleration.y != 0 && !isDead && !finish)
            rb.velocity += new Vector3(0, 0, Input.acceleration.y);
        if (Input.acceleration.x != 0 && !isDead && !finish)
            rb.velocity += new Vector3(Input.acceleration.x, 0, 0);


        // Управление для клавиатуры c ограничением
        if (Input.GetKey(KeyCode.W) && !isDead && !finish)
            rb.velocity += new Vector3(0, 0, speed);
        if (Input.GetKey(KeyCode.A) && !isDead && !finish)
            rb.velocity += new Vector3(-speed, 0, 0);
        if (Input.GetKey(KeyCode.D) && !isDead && !finish)
            rb.velocity += new Vector3(speed, 0, 0);
        if (Input.GetKey(KeyCode.S) && !isDead && !finish)
            //if (Input.GetKey(KeyCode.S) && (rb.velocity.z > -maxSpeed) && !isDead && !finish)
            rb.velocity += new Vector3(0, 0, -speed);
        // Прыжок
        if (Input.GetKeyUp(KeyCode.Space) && Physics.Raycast(transform.position, Vector3.down, out hit, 2f) && hit.transform.gameObject.tag == "Ground" && !isDead && !finish)
            rb.velocity += new Vector3(0, jump, 0);
        // ограничени скорости
        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed));

        // проверка проигрыша
        if (isDead)
        {
            from.SetActive(false);
            toL.SetActive(true);
        }

        // проверка победы
        if (finish)
        {
            from.SetActive(false);
            toW.SetActive(true);
        }

        // дебаг передвижения
        Debug.Log(previus);

        camPos.position = transform.position + new Vector3(0, 12, -8);
        ggPos.position = transform.position + new Vector3(0, 0, magic);
    }
    public void OnClick()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f) && hit.transform.gameObject.tag == "Ground" && !isDead && !finish)
            rb.velocity += new Vector3(0, jump, 0);
    }

    public void Onclick()
    {
        rb.velocity = new Vector3(0f, 0f, 0f);
    }
}

