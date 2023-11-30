using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombDropper : MonoBehaviour
{
    public GameObject bombPrefab;
    public float bombTime = 3f;
    public int bombs = 1;
    public int bombsLeft;
    public GameObject exploPre;
    public LayerMask exploLayer; 
    public float exploTime = 1f;
    public int exploRange = 1;

    GameObject countText;
    private bombCounter count;
    public GameObject bmbS;
   
    GameObject rangeText;
    private rangeCounter rangeCount;

    // Object pool variables
    public int poolSize = 10; // Number of bombs to pre-instantiate
    private List<GameObject> bombPool = new List<GameObject>();

    void Start()
    {
        countText = GameObject.Find("Bombs");
        count = countText.GetComponent<bombCounter>();
        bmbS = GameObject.Find("BombSound");

        rangeText = GameObject.Find("Range");
        rangeCount = rangeText.GetComponent<rangeCounter>();

        // Pre-instantiate bombs for the object pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bomb = Instantiate(bombPrefab);
            bomb.SetActive(false);
            bombPool.Add(bomb);
        }
    }

    private void OnEnable()
    {
        bombsLeft = bombs;
    }

    public void OnBomb()
    {
        if (bombsLeft > 0)
        {
            StartCoroutine(DropBomb());
        }
    }

    private void Update()
    {
        count.bombAmount.text = bombsLeft.ToString();
        rangeCount.rangeAmount.text = exploRange.ToString();
    }

    private IEnumerator DropBomb()
    {
        Vector2 position = transform.position;
        position.y += .3f;
        GameObject drop = GetPooledBomb();
        drop.transform.position = position;
        drop.SetActive(true);

        Collider2D bombCollider = drop.GetComponent<Collider2D>();
        if (bombCollider != null)
        {
            bombCollider.isTrigger = true; // Set the trigger status to true upon bomb spawn
        }

        bombsLeft--;
        count.bombAmount.text = bombsLeft.ToString();
        yield return new WaitForSeconds(bombTime);

        position = drop.transform.position;
        position.y -= .2f;

        GameObject explo = Instantiate(exploPre, position, Quaternion.identity);
        bmbS.GetComponent<AudioSource>().Play();
        Destroy(explo, exploTime);
        Explode(position, Vector2.up, exploRange);
        Explode(position, Vector2.down, exploRange);
        Explode(position, Vector2.right, exploRange);
        Explode(position, Vector2.left, exploRange);

        drop.SetActive(false); // Return the bomb to the object pool
        bombsLeft++;
        count.bombAmount.text = bombsLeft.ToString();
    }

    private GameObject GetPooledBomb()
    {
        foreach (GameObject bomb in bombPool)
        {
            if (!bomb.activeInHierarchy)
            {
                return bomb;
            }
        }
        return null;
    }


    private void Explode(Vector2 position, Vector2 direction, int range){
        if (range < 1){
            return;
        }
        position += direction;
        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, exploLayer)){
            return;
        }
        GameObject explo = Instantiate(exploPre, position, Quaternion.identity);
        Destroy(explo, exploTime);
        Explode(position, direction, range -1);
    }

     public void OnTriggerExit2D(Collider2D other){
          if(other.gameObject.layer == LayerMask.NameToLayer("Bomb")){
             other.isTrigger = false;
         }
     }
    
    
}
