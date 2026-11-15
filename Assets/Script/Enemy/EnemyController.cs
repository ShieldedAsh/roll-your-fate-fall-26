using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerRef;
    private Rigidbody2D rb;
    NavMeshAgent agent;

    /// <summary>
    /// Deltatime
    /// </summary>
    private float timer;

    [Tooltip("This enemy's AudioSource")]
    [SerializeField]
    private AudioSource audioSource;

    [Tooltip("List of footsteps to pick from")]
    [SerializeField]
    private List<AudioClip> footsteps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        agent = GetComponent<NavMeshAgent>();
        timer = 0.0f;
        audioSource.maxDistance = 30.0f;
    }

    void Update(){
        agent.destination = playerRef.transform.position;
        transform.rotation = Quaternion.identity;

        //Play a footstep every 0.3f seconds
        timer += Time.deltaTime;
        float distToPlayer = Vector3.Distance(playerRef.transform.position, transform.position);

        if(timer >= 0.3f)
        {
            if(distToPlayer <= audioSource.maxDistance)
            {
                //Make volume proportional to distance
                audioSource.volume = (audioSource.maxDistance / distToPlayer) / 30.0f;

                ////Sound is logarithmic
                //audioSource.volume = Mathf.Log(distToPlayer, 2.0f);
                audioSource.clip = GetFootstepSound();
                audioSource.Play();
            }

            timer -= 0.3f;
        }
    }

    /// <summary>
    /// Gets a random footstep sound
    /// </summary>
    public AudioClip GetFootstepSound()
    {
        int index = Random.Range(0, footsteps.Count);
        return footsteps[index];
    }
}
