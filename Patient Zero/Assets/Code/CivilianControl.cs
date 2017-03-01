using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CivilianControl : MonoBehaviour
{
    public bool isPatientZero;
    public bool hasDisease;
    public bool hasBeenInspected = false;
    public float timeSinceInfected = 0f;
    public float ForwardSpeed = 5f;
    private float nextFootprint;
    protected Animator animator;
    public GameObject inspectedIndicatorPrefab;
    public GameObject footprintsPrefab;
    public GameObject speechBubblePrefab;
    public GameObject speechTextPrefab;
    private GameLog gameLog;
    private Vector3 healthyBubbleScale;
    private Vector3 unhealthyBubbleScale;

    internal void Start ()
    {
	    hasDisease = false;
	    hasBeenInspected = false;
        animator = GetComponent<Animator>();
	    inspectedIndicatorPrefab = Instantiate(inspectedIndicatorPrefab);
	    inspectedIndicatorPrefab.GetComponent<SpriteRenderer>().enabled = false;
        speechBubblePrefab = Instantiate(speechBubblePrefab);
        speechBubblePrefab.GetComponent<SpriteRenderer>().enabled = false;
        speechTextPrefab = Instantiate(speechTextPrefab);
        gameLog = FindObjectOfType<GameLog>().GetComponent<GameLog>();
        healthyBubbleScale = speechBubblePrefab.transform.localScale - new Vector3(2, 0);
        unhealthyBubbleScale = speechBubblePrefab.transform.localScale;
    }
	
	internal void Update () {
	    if (hasDisease)
	    {
	        timeSinceInfected += Time.deltaTime;
	        speechBubblePrefab.gameObject.transform.position = transform.position + new Vector3(4.5f, 4.8f, -1f);
            speechTextPrefab.gameObject.transform.position = transform.position + new Vector3(-3, 7.5f, -2f);
            speechBubblePrefab.transform.localScale = unhealthyBubbleScale;
        }
	    else
	    {
            speechBubblePrefab.gameObject.transform.position = transform.position + new Vector3(2.75f, 4.8f, -1f);
            speechTextPrefab.gameObject.transform.position = transform.position + new Vector3(-2, 7.5f, -2f);
	        speechBubblePrefab.transform.localScale = healthyBubbleScale;
	    }
	    if (hasBeenInspected)
	    {
	        inspectedIndicatorPrefab.gameObject.transform.position = transform.position + new Vector3(0, 2.5f);
	    }
	    
        animator.SetBool("movingUp", false);
        animator.SetBool("movingRight", false);
        animator.SetBool("movingLeft", false);
        animator.SetBool("movingDown", false);
        engageBehavior();
	}

    internal abstract void engageBehavior();


    

    internal void trailFootprints(Vector3 footprintDirection)
    {
        if (Time.time > nextFootprint && hasBeenInspected)
        {
            GameObject footprint = Instantiate(footprintsPrefab, transform.position + new Vector3(0, -1.1f, 1), Quaternion.FromToRotation(Vector3.up, footprintDirection));
            nextFootprint = Time.time + 1;
            StartCoroutine(WaitAndDestory(10, footprint));
        }
    }

    public void inspect()
    {
        speechBubblePrefab.GetComponent<SpriteRenderer>().enabled = true;
        inspectedIndicatorPrefab.GetComponent<SpriteRenderer>().enabled = true;
        inspectedIndicatorPrefab.gameObject.transform.position = transform.position + new Vector3(0, 2.5f);
        if (hasDisease)
        {
            speechTextPrefab.GetComponent<TextMesh>().text = "I was infected " + (int)timeSinceInfected + "\nseconds ago!";
            StartCoroutine(WaitAndRemoveSpeech(5));
            inspectedIndicatorPrefab.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameLog.logText.text = "I was infected " + (int)timeSinceInfected + " seconds ago!";
            StartCoroutine(BlinkSprite(GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>(), Color.red));
        }
        else
        {
            speechTextPrefab.GetComponent<TextMesh>().text = "I'm healthy...";
            StartCoroutine(WaitAndRemoveSpeech(3));
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(33/255f, 64/255f, 156/255f);
            gameLog.logText.text = "I'm healthy bruh...";
        }
        hasBeenInspected = true;
    }

    IEnumerator WaitAndDestory(float secs, GameObject obj)
    {
        for (float i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(secs/10f);
            obj.GetComponent<SpriteRenderer>().color = new Color(0,0,0,1f-(i*0.1f));
        }
        yield return new WaitForSeconds(secs/10f);
        Destroy(obj);
    }

    IEnumerator WaitAndRemoveSpeech(float secs)
    {
        yield return new WaitForSeconds(secs);
        speechBubblePrefab.GetComponent<SpriteRenderer>().enabled = false;
        speechTextPrefab.GetComponent<TextMesh>().text = "";
    }

    IEnumerator BlinkSprite(SpriteRenderer sprite, Color color)
    {
        Color origColor = sprite.color;
        for (int i = 0; i < 4; i++)
        {
            sprite.color = color;
            yield return new WaitForSeconds(0.2f);
            sprite.color = origColor;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
