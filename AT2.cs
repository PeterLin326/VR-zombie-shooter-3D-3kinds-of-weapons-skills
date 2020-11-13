using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT2 : MonoBehaviour
{
    public float fireRate = 0.01f;
    public float nextFire = 0.0f;

    public Transform FirePosition1;
    public Transform FirePosition2;



    public GameObject weapon1_bullet;
    public GameObject weapon2_bullet;


    public float weapon1_speed = 5.0f;
    public float weapon2_speed = 30.0f;


    public GameObject CurrentWeapon;


    public GameObject g1;
    public GameObject g2;
    public GameObject g3;

    private float AttackDistance = 10.0f;//扇形距离
    private float AttackAngle = 60.0f;//扇形的角度

    private static LineRenderer GetLineRenderer(Transform t)
    {
        LineRenderer lr = t.GetComponent<LineRenderer>();
        if (lr == null)
        {
            lr = t.gameObject.AddComponent<LineRenderer>();
        }
        lr.SetWidth(0.1f, 0.1f);
        return lr;
    }


    void Start()
    {
        g1.SetActive(true);
        g2.SetActive(false);
        g3.SetActive(false);
        CurrentWeapon = g1;

    }



    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeapon = g1;
            g1.SetActive(true);
            g2.SetActive(false);
            g3.SetActive(false);

            


        }




        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentWeapon = g2;
            g1.SetActive(false);
            g2.SetActive(true);
            g3.SetActive(false);

            


        }



        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentWeapon = g3;
            g1.SetActive(false);
            g2.SetActive(false);
            g3.SetActive(true);

           


        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        Physics.Raycast(ray, out hit, 10000, LayerMask.GetMask("ground"));
        



        if (CurrentWeapon == g1 && hit.point != null && Input.GetButtonDown("Fire1"))
        {


            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            GameObject obj = Instantiate(weapon1_bullet);
            obj.transform.position = FirePosition1.position;
            Vector3 dir = (hit.point - FirePosition1.position) + new Vector3(0.0f, 0.6f, 0.0f).normalized;

            obj.GetComponent<Rigidbody>().velocity = dir * weapon1_speed;

            Destroy(obj, 35 * Time.deltaTime);
        }

        if (CurrentWeapon == g2 && Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject obj = Instantiate(weapon2_bullet);
            obj.transform.position = FirePosition2.position;
            obj.GetComponent<Rigidbody>().velocity = FirePosition2.forward * weapon2_speed;
            Vector3 dir = (hit.point - FirePosition2.position) + new Vector3(0.0f, 0.6f, 0.0f).normalized;
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            Destroy(obj, 35 * Time.deltaTime);


        }



        if (CurrentWeapon == g3)
        {
            //draw the attack area
            LineRenderer lr = GetLineRenderer(transform);
            int pointAmount = 100;//点的数目，值越大曲线越平滑    
            float eachAngle = AttackAngle / pointAmount;
            Vector3 forward = transform.forward;

            lr.SetVertexCount(pointAmount);
            lr.SetPosition(0, transform.position);
            lr.SetPosition(pointAmount - 1, transform.position);

            for (int i = 1; i < pointAmount - 1; i++)
            {
                Vector3 pos = Quaternion.Euler(0f, -AttackAngle / 2 + eachAngle * (i - 1), 0f) * forward * AttackDistance + transform.position;
                lr.SetPosition(i, pos);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                //attack
                GameObject a = GameObject.Find("Enemy");

                Vector3 dir = (hit.point - FirePosition2.position) + new Vector3(0.0f, 0.6f, 0.0f).normalized;
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                float distance = Vector3.Distance(transform.position, a.transform.position);

                Vector3 norVec = transform.rotation * Vector3.forward;
                Vector3 temVec = a.transform.position - transform.position;

                float Angle = Mathf.Acos(Vector3.Dot(norVec.normalized, temVec.normalized)) * Mathf.Rad2Deg;//compute the angle between two vectors
                if (distance < AttackDistance && Angle <= (AttackAngle / 2))
                {
                    EnemyHp.HitCounter -= 3;
                    if (EnemyHp.HitCounter <= 0)
                    {
                        Destroy(a.gameObject);
                    }
                }

            }

        }



    }
}























