using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControler2 : MonoBehaviour
{

    public float moveSpeed;
    public float turnSpeed;

    private Vector3 moveDirection;

	public GameObject music1;
	public GameObject music2;
	public GameObject shootmusic;
	public GameObject sound;

    Rigidbody rb;
    bool stop;

    public GameObject armor;

    public float point;

    private void Start()
    {
        stop = false;

        rb = GetComponent<Rigidbody>();

        armor.SetActive(false);

        ammo = 3;

        point = PlayerPrefs.GetFloat("point");

		Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public Text countText;
    public Text scorepoint;
    float score = 1;

    // SHOOTING

    //public GameObject bulletPrefab;
    public GameObject gun;

    public float speedbullet;

    public bullet BC;

    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;

    private int ammo = 3;

    //

    float NextBullet = 0f;

    public GameObject present;

    void Update()
    {
        if (point > PlayerPrefs.GetFloat("granica"))
        {
            present.SetActive(true);
        }

        if (stop == false)
            point++;

        moveDirection = new Vector3(0, 0, 1).normalized;

        if (Input.GetKey("left") && stop == false)
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey("right") && stop == false)
        {
            transform.Rotate(Vector3.down, -turnSpeed * Time.deltaTime);
        }

        if (stop == false)
            transform.Rotate(0, Input.acceleration.x * turnSpeed * Time.deltaTime, 0);

        ScoreCount();

        // SHOOTING

        bullet newBC;
        
        NextBullet++;

        if ((Input.touchCount > 0 && ammo > 0 && NextBullet > 30) || (Input.GetKey("space") && ammo > 0 && NextBullet > 30))
        {
			shootmusic.SetActive(false);

            newBC = Instantiate(BC, gun.transform.position, gun.transform.rotation) as bullet;
            newBC.speed = speedbullet;

            if (ammo > 0)
                ammo--;

            NextBullet = 0f;

			shootmusic.SetActive(true);
        }

        if (stop == true)
        {
            ammo = 0;
			music1.SetActive (true);
			music2.SetActive (false);
        }

        if (ammo == 3)
        {
            bullet1.SetActive(true);
            bullet2.SetActive(true);
            bullet3.SetActive(true);
        }

        if (ammo == 2)
        {
            bullet1.SetActive(true);
            bullet2.SetActive(true);
            bullet3.SetActive(false);
        }

        if (ammo == 1)
        {
            bullet1.SetActive(true);
            bullet2.SetActive(false);
            bullet3.SetActive(false);
        }

        if (ammo == 0)
        {
            bullet1.SetActive(false);
            bullet2.SetActive(false);
            bullet3.SetActive(false);
        }

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

        //if (Input.GetKeyDown("space"))
        //{
        //    GameObject bulletGO;
        //    bulletGO = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation) as GameObject;

        //    Rigidbody rbgm;
        //    rbgm = bulletGO.GetComponent<Rigidbody>();

        //    bulletGO.transform.Rotate(Vector3.right * 0);

        //    rbgm.AddForce(transform.forward * speedbullet );

        //    Destroy(bulletGO, 5.0f);
        //}
    }

    public GameObject gm;
    public GameObject boomprefab;
    public Transform bulletSpawn;

    public GameObject panel;
    public GameObject wynik;
    public GameObject play;
    public GameObject play2;

    public bool ArmorActive;

	int q = 0;

	void OnTriggerExit(Collider collider)
	{
		if (collider.tag == "rocket")
		{
			q = 0;
			sound.SetActive (false);
		}
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "rocket")
        {
			if (ammo == 2 && q == 0)
            {
                Destroy(collider.gameObject);
                ammo = 3;
				q = 1;
				sound.SetActive (true);
            }
			else if (ammo == 1 && q == 0)
            {
                Destroy(collider.gameObject);
                ammo = 2;
				q = 1;
				sound.SetActive (true);
            }
			else if (ammo == 0 && q == 0)
            {
                Destroy(collider.gameObject);
                ammo = 1;
				q = 1;
				sound.SetActive (true);
            }
        }

        if (collider.tag == "meteor" && !ArmorActive)
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;

            PlayerPrefs.SetFloat("point", point);

            var bullet = (GameObject)Instantiate(
            boomprefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
            Destroy(collider.gameObject);
            panel.SetActive(true);
            play.SetActive(false);
            play2.SetActive(true);
            wynik.SetActive(false);
            stop = true;

            if (score >= PlayerPrefs.GetFloat("Best"))
                PlayerPrefs.SetFloat("Best", score);


            tekst.SetActive(true);
        }
        if (collider.tag == "meteor" && ArmorActive == true)
        {
            armor.SetActive(false);
            ArmorActive = false;
            Destroy(collider.gameObject);
        }

        if (collider.tag == "armor")
        {
			sound.SetActive (false);
            armor.SetActive(true);
            ArmorActive = true;
            Destroy(collider.gameObject);
			sound.SetActive (true);
        }

    }

    int a = 0;

    public Text scoretext;

    public GameObject tekst;

    void ScoreCount()
    {
        if (stop == false)
        {
            a++;
            if (a >= 20)
            {
                score++;
                a = 0;
            }
        }

        float bestscore = PlayerPrefs.GetFloat("Best");

        countText.text = "Distance" + score;
        scorepoint.text = "Best score  " + bestscore;
        scoretext.text = "Score  " + score;
        
    }

    public GameObject gameover;

    public void StartGame()
    {
        stop = false;
        gameover.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

}