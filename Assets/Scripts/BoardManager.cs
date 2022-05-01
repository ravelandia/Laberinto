using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    [SerializeField] private Cell CellPrefab;
    [SerializeField] private Player PlayerPrefab;



    public HeroMovement HeroMovement;
    public LayerMask mascara;
    private Grid grid;
    private Player player;
    [SerializeField]
    private float moveSpeed = 2f;

    public Dropdown dropdown;
    public Button button;

    //funcion update

    void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        //pasar el valor de dropdown a entero

        var valor =dropdown.value;
        int Tam= int.Parse(dropdown.options[valor].text);
        //cuando de click en el boton
        button.onClick.AddListener(() =>
        {
            //Elimina dropdown
            Destroy(dropdown.gameObject);
            //Elimina boton
            Destroy(button.gameObject);
            Debug.Log("Tam: " + Tam);
            grid = new Grid(Tam, Tam, 1, CellPrefab, mascara);

            player = Instantiate(PlayerPrefab, new Vector3(0, 0,1), Quaternion.identity); 
            HeroMovement=Instantiate(HeroMovement, new Vector3(0, 1,1), Quaternion.identity); 
        });

        
    }

    public void CellMouseClick(int x, int y)
    {
        List<Cell> path = PathManager.Instance.FindPath(grid, (int)player.GetPosition.x, (int)player.GetPosition.y, x, y);

        player.SetPath(path);
    }

}
