using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public float ForwardSpeed;
	public ItemControl item;
    public LayerMask layerMask;
    private Animator animator;
    private PlayerStats playerStats;
    private Timer timer;

    internal void Start()
    {
        layerMask = ~layerMask;
        animator = GetComponent<Animator>();
        playerStats = FindObjectOfType<PlayerStats>().GetComponent<PlayerStats>();
        timer = FindObjectOfType<Timer>().GetComponent<Timer>();
    }
    internal void Update()
    {
        animator.SetBool("movingUp", false);
        animator.SetBool("movingRight", false);
        animator.SetBool("movingLeft", false);
        animator.SetBool("movingDown", false);
        if (Input.GetKey(KeyCode.W))
        {
            move(ForwardSpeed, Vector3.up, "movingUp");
        }
        if (Input.GetKey(KeyCode.A))
        {
            move(ForwardSpeed, Vector3.left, "movingLeft");
        }
        if (Input.GetKey(KeyCode.D))
        {
            move(ForwardSpeed, Vector3.right, "movingRight");
        }
        if (Input.GetKey(KeyCode.S))
        {
            move(ForwardSpeed, Vector3.down, "movingDown");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject closestCivilian = getCloesestCivilian();
            if (closestCivilian != null && closestCivilian.GetComponent<CivilianControl>().hasDisease)
            {
                closestCivilian.GetComponent<CivilianControl>().inspect();
                playerStats.reduceHealth(10);
            }
            else if (closestCivilian != null)
            {
                closestCivilian.GetComponent<CivilianControl>().inspect();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject closestCivilian = getCloesestCivilian();
            if (closestCivilian != null && closestCivilian.GetComponent<CivilianControl>().isPatientZero)
            {
                timer.GameOver(true);
            }
            else if (closestCivilian != null)
            {
                playerStats.useVaccine();
				closestCivilian.GetComponent<CivilianControl> ().vaccinateNotPatientZero ();
            }
        }
    }

    private void move(float speed, Vector3 direction, string animationVariable)
    {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, direction, speed * Time.deltaTime, layerMask);
		if (hit == false || hit.collider.isTrigger == true)
            transform.position += speed*direction*Time.deltaTime;
        animator.SetBool(animationVariable, true);
    }

    private GameObject getCloesestCivilian()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 3, layerMask);
        GameObject closestCivilian = null;
        float closestCivilianDistance = float.PositiveInfinity;
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.tag.Equals("Civilian"))
            {
                GameObject civilian = collider.gameObject;
                float distanceToCivilian = Vector3.Distance(transform.position, civilian.transform.position);
                if (distanceToCivilian < closestCivilianDistance)
                {
                    closestCivilian = civilian;
                    closestCivilianDistance = distanceToCivilian;
                }
            }
        }
        return closestCivilian;
    }

}
