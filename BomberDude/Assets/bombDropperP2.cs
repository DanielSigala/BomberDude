using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombDropperP2 : MonoBehaviour
{
    public GameObject bomb;
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
   void Start(){
       countText = GameObject.Find("Bombs2");
       count = countText.GetComponent<bombCounter>();
       bmbS = GameObject.Find("BombSound");

       rangeText = GameObject.Find("Range2");
       rangeCount = rangeText.GetComponent<rangeCounter>();
    }

    private void OnEnable(){
        bombsLeft = bombs;
    }

    private void Update(){
        count.bombAmount.text = bombsLeft.ToString();
        rangeCount.rangeAmount.text = exploRange.ToString();
        if (bombsLeft > 0 && Input.GetKeyDown(KeyCode.Keypad0)){
            StartCoroutine(dropBomb());
        }
    }

    private IEnumerator dropBomb(){
        Vector2 position = transform.position;
        position.y += .3f;
        GameObject drop = Instantiate(bomb, position, Quaternion.identity);
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
        Destroy(drop);
        bombsLeft++;
        count.bombAmount.text = bombsLeft.ToString();
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
