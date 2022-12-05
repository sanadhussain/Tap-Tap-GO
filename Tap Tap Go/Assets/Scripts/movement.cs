using UnityEngine;
using UnityEngine.Advertisements;

public class movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Player;
    public float speed = 5f;
    public Vector2 Jumpforce;
    public Vector2 SideForce;
    private bool left;
    private bool right;
    [SerializeField] private AudioSource jumpsound;
    [SerializeField] private GameObject resume;

    private void Start()
    {
        print("Hiding Banner Ad");
        AdsIntializer.Instance.HideBannerAd();
    }
    void start(){
        
        left=false;
        right=false;
    }
    void Update()
    {
        if(left)
        {
            Player.AddForce(new Vector2(-SideForce.x * Time.deltaTime, SideForce.y));
            /*Vector2 pos = transform.position;
            pos.x += -1 * Time.deltaTime * speed;
            transform.position = pos;*/
        }
         if(right)
        {
            Player.AddForce(new Vector2(SideForce.x * Time.deltaTime, SideForce.y));
            /*Vector2 pos = transform.position;
            pos.x += 1 * Time.deltaTime * speed;
            transform.position = pos;*/
        }
        /*if (Input.GetButtonDown("Fire3"))
        {
            if((left == right) && resume.activeInHierarchy)
            {
            GetComponent<Rigidbody2D>().AddForce(Jumpforce);
            jumpsound.Play();
            }
        }*/

    }
    public void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Jumpforce);
        jumpsound.Play();
    }
    public void leftdown()
    {
        left=true;
    }

    public void leftup()
    {
        left=false;
    }
    public void rightdown()
    {
        right=true;
    }

    public void rightup()
    {
        right=false;
    }
}
