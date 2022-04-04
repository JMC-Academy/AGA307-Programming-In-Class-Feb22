using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : GameBehaviour
{
    float moveDistance = 500;
    Animator anim;
    int hitPoints = 3;

    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(MoveRandom());
    }

    public void Hit()
    {
        hitPoints--;
        if (hitPoints != 0)
        {
            anim.SetTrigger("Hit");
        }
        else
        {
            anim.SetTrigger("Die");
            Destroy(gameObject, 1);
        }
    }

    IEnumerator Move()
    {
        for(int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(Move());
    }

    IEnumerator MoveRandom()
    {
        Vector3 direction = new Vector3();
        int rnd = Random.Range(0, 6);
        if (rnd == 0)   direction = Vector3.back;
        if (rnd == 1)   direction = Vector3.forward;
        if (rnd == 2)   direction = Vector3.left;
        if (rnd == 3)   direction = Vector3.right;
        if (rnd == 4)   direction = Vector3.up;
        if (rnd == 5)   direction = Vector3.down;

        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate(direction * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(MoveRandom());
    }
}
