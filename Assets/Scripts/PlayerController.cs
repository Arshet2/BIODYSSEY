using UnityEngine;

public class PlayerController : MonoBehaviour
{

//<>

private Rigidbody2D rb;
 
    public float velocidadDemovimiento = 10;
    public float fuerzaDeSalto = 5;

    private Vector2 direccion; 


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


        direccion = new Vector2(x, y);
        
        Caminar();

        MejorarSalto();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            saltar();
        }    
    }

    private void MejorarSalto()
    {
      if(rb.linearVelocity.y < 0)
      {
        rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
      }  
      else if(rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
      {
        rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (2.0f -1) * Time.deltaTime;                     
      }
    }

    private void saltar()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.linearVelocity +=  Vector2.up * fuerzaDeSalto;
    }

    private void Caminar()
    {
        rb.linearVelocity = new Vector2(direccion.x * velocidadDemovimiento, rb.linearVelocity.y);
    }

}
