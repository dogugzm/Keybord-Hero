using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using Cinemachine;


public enum PlayerState
{
    RUNNING,
    INJURED,
    ATTACK,
    VICTORY
}

public class PlayerController : MonoBehaviour
{

    public float speed;
    public bool rightEdge;
    public bool leftEdge;

    public GameObject Box;
    //public TextMeshProUGUI textTry;

    public GameObject LetterNumber;
    public GameObject camPosRight;
    public GameObject camPosLeft;

    bool canMove;

    public PlayerState currentState;

    public List<GameObject> letterLists = new List<GameObject>();

    public Animator animator;

    CinemachineVirtualCamera vcam;
    CinemachineBasicMultiChannelPerlin noise;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        leftEdge = false;
        rightEdge = false;
        speed = 1f;
        currentState = PlayerState.RUNNING;

        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            Movement();
        }
        
        AnimationControl();
        CheckWall();

        if (currentState == PlayerState.ATTACK)
        {
            canMove = false;
            
        }        


        LetterNumber.GetComponent<TextMeshPro>().text = letterLists.Count + "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Letter"))
        {
            letterLists.Add(other.gameObject);
            string hittedLetter = other.gameObject.GetComponent<TextMeshPro>().text;
            Box.GetComponent<TextMeshPro>().text = Box.GetComponent<TextMeshPro>().text + "" + hittedLetter;
            other.gameObject.GetComponent<TextMeshPro>().DOColor(Color.white, 1f);
        }

        if (other.CompareTag("Obstacle")|| other.CompareTag("ObtsacleAxe"))
        {
            StartCoroutine(Injured());
            StartCoroutine(AddNoise(1, 1, 1));
        }

        if (other.CompareTag("Boss"))
        {
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        currentState = PlayerState.ATTACK;
        vcam.Follow = null;
        vcam.transform.DOLocalMove(camPosRight.transform.position, 2f);
        vcam.transform.DOLocalRotate(camPosRight.transform.rotation.eulerAngles, 2f);
        yield return new WaitForSeconds(3f);
        vcam.transform.DOLocalMove(camPosLeft.transform.position, 2f);
        vcam.transform.DOLocalRotate(camPosLeft.transform.rotation.eulerAngles, 2f);

    }
    public IEnumerator Injured()
    {
        DropLetter();
        currentState = PlayerState.INJURED;
        yield return new WaitForSeconds(1f);
        currentState = PlayerState.RUNNING;
    }
    public void DropLetter()
    {
        Box.GetComponent<TextMeshPro>().text = Box.GetComponent<TextMeshPro>().text.Remove(Box.GetComponent<TextMeshPro>().text.Length - 1);
        letterLists.RemoveAt(letterLists.Count - 1);

    }
    private void AnimationControl()
    {
        if (currentState == PlayerState.RUNNING)
        {
            animator.SetBool("Running", true);
            animator.SetBool("Injured", false);

        }
        else if (currentState==PlayerState.INJURED)
        {
            animator.SetBool("Injured", true);
            animator.SetBool("Running", false);
        }
        else if (currentState==PlayerState.ATTACK)
        {
            animator.SetBool("Attack", true);
            animator.SetBool("Running", false);
            animator.SetBool("Injured", false);
        }
        else if (currentState == PlayerState.VICTORY)
        {
            animator.SetBool("Victory", true);
            animator.SetBool("Attack", false);
            
        }
    }
    private void CheckWall()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.right);
        Ray rayLeft = new Ray(transform.position, Vector3.left);

        if (Physics.Raycast(ray, out hit, 2f))
        {
            if (hit.collider.CompareTag("RightWall"))
            {
                rightEdge = true;
            }

        }
        else
        {
            rightEdge = false;
        }

        if (Physics.Raycast(rayLeft, out hit, 2f))
        {
            if (hit.collider.CompareTag("LeftWall"))
            {
                leftEdge = true;
            }

        }
        else
        {
            leftEdge = false;

        }
    }
    private void Movement()
    {
        transform.DOMoveZ(transform.position.z + 2, speed);

        if (Input.GetKey(KeyCode.A) && !leftEdge)
        {
            StartCoroutine(RotatePlayer(-10f));
            transform.DOMoveX(transform.position.x - 1, 0.5f);
        }
        else if (Input.GetKey(KeyCode.D) && !rightEdge)
        {
            StartCoroutine(RotatePlayer(10f));
            transform.DOMoveX(transform.position.x + 1, 0.5f);
        }
    }
    public IEnumerator RotatePlayer(float degree)
    {
        transform.DORotate(transform.eulerAngles + new Vector3(0, degree, 0), 0.5f);
        yield return new WaitForSeconds(0.2f);
        transform.DORotate(new Vector3(0, 0, 0), 0.5f);
    }
    public IEnumerator AddNoise(float n1, float n2, float time)
    {
        noise.m_AmplitudeGain = n1;
        noise.m_FrequencyGain = n2;
        yield return new WaitForSeconds(time);
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;

    }

    private void OnDrawGizmosSelected()
    {
        //Debug.DrawRay(transform.position, Vector3.forward * 1f,Color.red);
    }
}

