using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    GameObject obj;
    private float movePower = 1;
    private float moveSpeed = 6;
    public float jumPower = 7;
    private Animator anim;
    private bool D = false;
    private bool A = false;
    private SpriteRenderer PlayerSpriteRenderer;
    public bool touchTheGround = false;
    private int count = 0;
    // Start is called beore the first frame update
    void Start()
    {
        obj = gameObject;
        anim = obj.GetComponent<Animator>();
        anim.SetBool("die", false);
        anim.SetBool("jum", false);
        anim.SetBool("move_right", false);
        anim.SetBool("move_left", false);
        PlayerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            D = true;
            A = false;

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            D = false;
            anim.SetBool("move_right", false);
        }

        if (D == true)
        {
            // obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed * Time.deltaTime * movePower, 0));
            obj.transform.Translate(new Vector3(moveSpeed * Time.deltaTime * movePower, 0, 0));
            // obj.transform.localScale = new Vector3(obj.transform.localScale.x, obj.transform.localScale.y, obj.transform.localScale.z);
            anim.SetBool("move_right", true);
            PlayerSpriteRenderer.flipX = false;

        }

        ///khu cua a

        if (Input.GetKeyDown(KeyCode.A))
        {
            A = true;
            D = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            A = false;
            anim.SetBool("move_left", false);
        }

        if (A == true)
        {
            // obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveSpeed * Time.deltaTime * movePower, 0)); 
            obj.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime * movePower, 0, 0));
            // obj.transform.localScale = new Vector3(-(obj.transform.localScale.x), obj.transform.localScale.y, obj.transform.localScale.z);
            anim.SetBool("move_left", true);
            PlayerSpriteRenderer.flipX = true;
        }

        ///khu cua w

        if (Input.GetKeyDown(KeyCode.W) && touchTheGround)
        {
            // obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumPower)); 
            // obj.transform.Translate(new Vector3(0, 8 * Time.deltaTime * jumPower , 0));
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumPower), ForceMode2D.Impulse);
            // obj.transform.localScale = new Vector3(-(obj.transform.localScale.x), obj.transform.localScale.y, obj.transform.localScale.z);
            anim.SetBool("jum", true);
            touchTheGround = false;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("wall"))
        {
            touchTheGround = true;
            count = 0;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("wall"))
        {
            touchTheGround = false;
            anim.SetBool("jum", false);
        }
    }

}



