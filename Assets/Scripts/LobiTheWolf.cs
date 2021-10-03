using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobiTheWolf : MonoBehaviour
{
    private static LobiTheWolf instance;
    public ChangeSceneManager changeSceneManager;
    public Animator animator;
    public int speed;
    public bool moving;
    public GameObject target;
    private Inventory inventory;
    private string goToSceneName;

    // Start is called before the first frame update
    void Start()
    {
        initSingletionInstance();
        inventory = GameObject.FindGameObjectWithTag("Lobi").GetComponent<Inventory>();
        changeSceneManager = GameObject.FindGameObjectWithTag("SceneControl").GetComponent<ChangeSceneManager>();
    }

    void initSingletionInstance()
    {
        if (instance == null) // This is first object, set the static reference
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfNeedsToMove();
    }

    public void WalkToPositionAndLoadScene(GameObject go, string sceneName)
    {
        moving = true;
        target = go;
        checkIfLobiMustBeFlipped(go.transform.position);
        goToSceneName = sceneName;
    }

    public void WalkToPositionAndDestroy(GameObject go)
    {
        moving = true;
        target = go;
        checkIfLobiMustBeFlipped(go.transform.position);
    }

    public void CheckIfNeedsToMove()
    {
        if(moving)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            animator.SetFloat("Speed", 1);
            if (Vector3.Distance(transform.position, target.transform.position) < 0.001f)
            {
                if (goToSceneName != null)
                {
                    moving = false;
                    animator.SetFloat("Speed", 0);
                    var xPosition = transform.position.x > 0 ? -6 : 6;
                    transform.position = new Vector3(xPosition, transform.position.y, 0);
                    changeSceneManager.LoadScene(goToSceneName);
                    goToSceneName = null;
                }
                else
                {
                    moving = false;
                    animator.SetFloat("Speed", 0);
                    inventory.AddToInventory(target);
                }
            }
        }
    }

    public void checkIfLobiMustBeFlipped(Vector3 position)
    {
        var currentXPos = transform.position.x;
        var targetXPos = position.x;
        var needToChange = false;
        // First Case - Not flipped and moves right
        if(!GetComponent<SpriteRenderer>().flipX)
        {
            if(targetXPos < currentXPos)
            {
                needToChange = true;
            }
        } else
        {
            if(targetXPos > currentXPos)
            {
                needToChange = true;
            }
        }
        if(needToChange)
        {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }
    }
}
