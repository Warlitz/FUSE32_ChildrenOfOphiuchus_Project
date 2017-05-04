using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    private float run_speed;
    [SerializeField]
    private float jump_speed;

    [SerializeField]
    private float effect_time;
    [SerializeField]
    private float result_time;
    [SerializeField]
    private GameObject effect;

    [SerializeField]
    private GameObject recovery_effect;

    [SerializeField]
    private string SceneName;

    [SerializeField]
    private Sprite jump_sprite;
    [SerializeField]
    private Sprite[] run_sprites;
   

    [SerializeField,Header("絵の切り替わる間隔")]
    private float animeTime;

    private Sprite defo;//最初の絵
    private float Timer = 0;//経過時間
    private float deadTimer = 0;
    private bool IsJump = false;
    private bool IsDead = false;
    private GameObject init_recovery_effect;

    GameObject hiteffect;

    private SpriteRenderer render;

	void Start () {
        render = GetComponent<SpriteRenderer>();
        defo = render.sprite;
	}

    void Update()
    {
        if (!IsDead)
            PlayerMove();
        else
            HitEffect();

        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.JoystickButton0))
        {
            if (!init_recovery_effect)
            {
                init_recovery_effect = (GameObject)Instantiate(recovery_effect, transform.position, Quaternion.identity);
                init_recovery_effect.transform.parent = this.transform;
            }
        }

        else
            Destroy(init_recovery_effect);

        ChangeSprite();
    }

    void PlayerMove()
    {
        if ((Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton2))  && !IsJump)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jump_speed;
            IsJump = true;
        }

        transform.position += Vector3.right * Input.GetAxis("Horizontal") * run_speed * Time.deltaTime;
    }

    void ChangeSprite()
    {
        if (Input.GetAxis("Horizontal") != 0 || IsJump)
        {
            Timer += Time.deltaTime;

            if (Input.GetAxis("Horizontal") > 0)
                render.flipX = false;
            else if (Input.GetAxis("Horizontal") < 0)
                render.flipX = true;

            if (IsJump) {
                Timer = 0;
                render.sprite = jump_sprite;
            }

            else
                render.sprite = run_sprites[(int)(Timer / animeTime) % run_sprites.Length];
        }

        else
        {
            Timer = 0;
            render.sprite = defo;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsJump)
        {
			if (collision.transform.position.y < transform.position.y)
                IsJump = false;
        }

        if (collision.gameObject.tag == "Thunder"&&!IsDead)
        {
            IsDead = true;
            hiteffect = (GameObject)Instantiate(effect, transform.position, Quaternion.identity);
            hiteffect.transform.parent = this.transform;
            this.gameObject.layer = LayerMask.NameToLayer("DeadPlayer");
            Invoke("ToNextScene", result_time);
        }
    }

    void ToNextScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    void HitEffect()
    {
        deadTimer += Time.deltaTime;

        Color alpha = Color.white;
        alpha.a = 1 - deadTimer / effect_time;
        render.color = alpha;
        hiteffect.GetComponent<SpriteRenderer>().color = alpha;

        if (deadTimer > effect_time)
            deadTimer = 0;
    }
}
