using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    // 명령어 띄울 말풍선
    public GameObject balloon;
    public GameObject balloon_text1;
    public GameObject balloon_text2;
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

    // 대화창
    public DialogueManager manager;

    Camera mainCamera;
    RectTransform rectTransform;
    Vector2 targetPosition;
    RaycastHit2D hit;

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
            AudioSource jump = GetComponent<AudioSource>();
            jump.Play();
        }
        //Stop Speed
        if (Input.GetButtonUp("Horizontal")) {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        //Direction Sprite
        if (manager.isAction == false && Input.GetButton("Horizontal"))
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
            AudioSource jump = GetComponent<AudioSource>();
            jump.Play();
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

        // 명령어 체크
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            BoolOnonSelected();
        }
    }
    void FixedUpdate()
    {
        //PC
        //Move Speed
        float h = manager.isAction? 0 :Input.GetAxisRaw("Horizontal");
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
            //balloon.SetActive(true);

            Collider2D scanObjectCollider = scanObject.GetComponent<Collider2D>();

            // 스캔된 오브젝트의 Collider가 있을 경우에만 위치 계산
            if (scanObjectCollider != null)
            {
                float yOffset = 0.5f; // 말풍선이 오브젝트 위에 떠 있는 높이
                float balloonPosY = scanObjectCollider.bounds.max.y + yOffset;

                // 말풍선의 위치를 설정
                // balloon.transform.position = new Vector3(scanObject.transform.position.x - 0.5f, balloonPosY, 0f);


                // 조건식으로 스캔된 오브젝트에 따라 명령어를 다르게 보여주려고 합니다.
                if (scanObject.tag == "object") {
                    balloon_text1.SetActive(true);
                    balloon_text1.transform.localPosition = new Vector3(scanObject.transform.position.x - 0.5f, balloonPosY, 0f);
                }
                if (scanObject.tag == "npc" || scanObject.tag == "StoreCat")
                {
                    balloon_text2.SetActive(true);
                    balloon_text2.transform.localPosition = new Vector3(scanObject.transform.position.x - 1f, balloonPosY + 0.25f, 0f);
                }
                if (scanObject.tag =="DizzyCat")
                {
                    // 물체가 감지되지 않을 때 말풍선을 비활성화하고 추가 이미지도 제거
                    balloon.SetActive(false);
                    balloon_text1.SetActive(false);
                    balloon_text2.SetActive(false);
                    scanObject = null;

                    // 추가 이미지 오브젝트가 있다면 제거
                    Transform additionalImageTransform = balloon.transform.Find("YourAdditionalImagePrefabName");
                    if (additionalImageTransform != null)
                    {
                        Destroy(additionalImageTransform.gameObject);
                    }
                }
            }

            // Debug.Log("scan : " + scanObject.name);


        }
        else
        {
            // 물체가 감지되지 않을 때 말풍선을 비활성화하고 추가 이미지도 제거
            balloon.SetActive(false);
            balloon_text1.SetActive(false);
            balloon_text2.SetActive(false);
            scanObject = null;

            // 추가 이미지 오브젝트가 있다면 제거
            Transform additionalImageTransform = balloon.transform.Find("YourAdditionalImagePrefabName");
            if (additionalImageTransform != null)
            {
                Destroy(additionalImageTransform.gameObject);
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (scanObject != null)
            {
                Debug.Log("T key : " + scanObject.name);
                manager.Action(scanObject.name);
            }
        }
        */
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

    void BoolOnonSelected()
    {
        // Debug.Log(scanObject.name);

        if (hit.collider != null || scanObject != null)
        {
            if (scanObject.tag != "Dizzy Cat")
            {
                targetPosition = hit.transform.position;
                if (hit.collider.tag == "balloon")
                    manager.Action(scanObject.name);
            }
        }
    }
}
