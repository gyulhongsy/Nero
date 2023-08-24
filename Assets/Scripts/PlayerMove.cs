using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public float jumpPower;
    //Mobile key var
    int left_Value;
    int right_Value;
    bool up_down;
    bool left_down;
    bool right_down;
    bool left_Up;
    bool right_Up;

    //스테이지 전환용
    public List<string> nextStageNames = new List<string> { "NeroHouse", "Chap12", "Chap3", "Chap4", "CatPlanet" }; // 초기 스테이지 이름 리스트
    private bool nextStage = false;
    private int nextStageIndex = 0;
    private int currentStageIndex = 0;

    // 오브젝트 스캔
    float direction;
    float detectRange = 2.0f;
    GameObject scanObject;

    public DialogueManager manager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        // 현재 스테이지의 인덱스를 찾아냅니다.
        string currentSceneName = SceneManager.GetActiveScene().name;
        currentStageIndex = nextStageNames.IndexOf(currentSceneName);
    }

    void Update()
    {
        //PC
        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping")) {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
        //Stop Speed
        if (Input.GetButtonUp("Horizontal")) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //Direction Sprite
        if (Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == 1;

            if (Input.GetAxisRaw("Horizontal") == -1.0)
            {
                // Debug.Log("left");
                direction = -1.0f;
            }
            else
            {
                // Debug.Log("right");
                direction = 1.0f;
            }
        }

        //Moblie
        //Jump
        if (up_down && !anim.GetBool("isJumping")) {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
        //Stop Speed
        if (right_Up && left_Up) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //Direction Sprite
        if (left_down || right_down)
        {
            spriteRenderer.flipX = (right_Value + left_Value) == 1;
        }

        //스테이지 전환용
        string currentSceneName = SceneManager.GetActiveScene().name;
        currentStageIndex = nextStageNames.IndexOf(currentSceneName);

        //Mobile Var Init
        up_down = false;
        left_down = false;
        right_down = false;
        left_Up = false;
        right_Up = false;


        if (Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }
    void FixedUpdate()
    {
        //PC
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Mobile
        //Move Speed
        h = right_Value + left_Value;
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if (rigid.velocity.x > maxSpeed) //Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) //Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        //Landing Platform
        if (rigid.velocity.y < 0)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platforms"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                    anim.SetBool("isJumping", false);
            }
        }

        //Debug.DrawRay(rigid.position, new Vector3(direction * detectRange, (float)0.0), new Color(0, 0, 1));

        RaycastHit2D rayHitDetect = Physics2D.Raycast(rigid.position, new Vector3(direction, (float)0.0), detectRange, LayerMask.GetMask("Object"));

        if (rayHitDetect.collider != null)
        {
            // 물체를 인식했을 때
            scanObject = rayHitDetect.collider.gameObject;

            // 해당하는 명령어가 보이게 작성해주시면 됩니다

            // Debug.Log("scan : " + scanObject.name);
        }
        else
        {
            scanObject = null;
        }

        // T키를 누르면 스캔된 물체 대사 진행 -> 후에 삭제
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (scanObject != null)
            {
                Debug.Log("T key : " + scanObject.name);
                manager.Action(scanObject.name);
            }
        }

    }
    //Mobile
    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                up_down = true;
                break;
            case "L":
                left_Value = -1;
                left_down = true;
                break;
            case "R":
                right_Value = 1;
                right_down = true;
                break;
        }
    }
    public void ButtonUp(string type)
    {
        switch (type) {
            case "U":
                up_down = false;
                break;
            case "L":
                left_Value = 0;
                left_Up = true;
                break;
            case "R":
                right_Value = 0;
                right_Up = true;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("warmHole"))
        {
            nextStage = true;
            LoadNextStage();
        }
    }

    void LoadNextStage()
    {
        // 다음 스테이지 인덱스를 계산합니다.
        int nextStageIndex = (currentStageIndex + 1) % nextStageNames.Count;

        string nextStageName = nextStageNames[nextStageIndex];
        SceneManager.LoadScene(nextStageName);
    }
}
