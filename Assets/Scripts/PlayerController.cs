using UnityEngine;

public class PlayerController : MonoBehaviour
{

//<>

    private Rigidbody2D rb;
    private Vector2 direccion; 

    [Header("Estadisticas")]
 
    public float velocidadDemovimiento = 10;
    public float fuerzaDeSalto = 5;

    [Header("Colisiones")]
    public LayerMask LayerPiso;
    public float radioDeColision;
    public Vector2 abajo;

    [Header("Booleanos")]
    public bool puedeMover = true;
    public bool enSuelo = true;
    


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
        Agarres();
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
            if(enSuelo)
            {
              saltar();
            }
            
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

    private void Agarres()
    {
      enSuelo = Physics2D.OverlapCircle((Vector2)transform.position + abajo, radioDeColision, LayerPiso);
    }

    private void saltar()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.linearVelocity +=  Vector2.up * fuerzaDeSalto;
    }

    private void Caminar()
    {
        if(puedeMover)
        {
          rb.linearVelocity= new Vector2(direccion.x * velocidadDemovimiento, rb.linearVelocity.y);

          if(direccion != Vector2.zero)
          {
            if(direccion.x < 0 && transform.localScale.x > 0)
            {
               transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }else if(direccion.x > 0 && transform.localScale.x < 0) 
            {
               transform.localScale = new Vector3(Mathf.Abs (transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
         }
      }
        
    }

}
