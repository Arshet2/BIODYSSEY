using UnityEngine;

public class PlayerController : MonoBehaviour
{

//<>

private Rigidbody2D rb;
 
    public float velocidadDemovimiento = 10;


    private void Awake() 
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento(); 
    }


    private void Movimiento()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        Vector2 direccion = new Vector2(x, y);
        
        Caminar(direccion);
    }

    private void Caminar(Vector2 direccion)
    {
        rb.linearVelocity = new Vector2(direccion.x * velocidadDemovimiento, rb.linearVelocity.y);
    }

}
