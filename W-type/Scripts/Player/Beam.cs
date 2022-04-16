using System.Collections;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty
    }
   public State state { get; private set; }
   public ParticleSystem beam;

   public float damage = 40;
   public float fireDistance;

   public float timeBetFire = 0.25f;
   private float lastFireTime;

   private void Awake()
    {
    
    }

    
  private  void OnEnable()
    {
        state = State.Ready;
        lastFireTime = 0;
        
    }

    public void Fire()
    {
        if(state == State.Ready && Time.time >= lastFireTime + timeBetFire  )
        {
            lastFireTime = Time.time;
            Shot();
        }
    }

    private void Shot()
    {
        StartCoroutine(ShotEffect());
    }

    private IEnumerator ShotEffect()
    {
        beam.Play();
  
        yield return new WaitForSeconds(0.03f);
  
    }
}
