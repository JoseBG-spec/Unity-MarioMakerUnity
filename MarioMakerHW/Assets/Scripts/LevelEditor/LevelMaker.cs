using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMaker : MonoBehaviour
{
    public Tile[] tiles,playersTiles,platformTiles,enemiesTiles;
    public GameObject buttonPrefab,backButton,background;
    public Transform layout;
    public SpriteRenderer preview;
    public GameObject[] playingObjects,mainMenu;
    private GameObject[] tilesSet,players,platforms,enemies;
    public Sprite[] bgSprites;
    private string currentMenu;
    private int currentBackground;

    private Vector3 pos;
    int id;

    public static bool playing;

    void Start()
    {
        InstantiateTiles();
        InstantiateEnemies();
        InstantiatePlatforms();
        InstantiatePlayers();
        currentBackground=0;

    }
    private void InstantiateTiles()
    {
        tilesSet = new GameObject[10];
        for (int i = 0; i < tiles.Length; i++)
        {
            int u = i;
            var t = Instantiate(buttonPrefab, layout);
            t.GetComponent<Image>().sprite = tiles[u].sprite;
            t.GetComponent<Button>().onClick.AddListener(() =>
            {
                id = u;
                preview.sprite = tiles[u].sprite;
            });
            t.SetActive(false);
            tilesSet[i] = t;
        }
    }
    private void InstantiatePlayers()
    {
        players = new GameObject[10];
        for (int i = 0; i < playersTiles.Length; i++)
        {
            int u = i;
            var t = Instantiate(buttonPrefab, layout);
            t.GetComponent<Image>().sprite = playersTiles[u].sprite;
            t.GetComponent<Button>().onClick.AddListener(() =>
            {
                id = u;
                preview.sprite = playersTiles[u].sprite;
            });
            t.SetActive(false);
            players[i] = t;
        }
    }
    private void InstantiatePlatforms()
    {
        platforms = new GameObject[10];
        for (int i = 0; i < platformTiles.Length; i++)
        {
            int u = i;
            var t = Instantiate(buttonPrefab, layout);
            t.GetComponent<Image>().sprite = platformTiles[u].sprite;
            t.GetComponent<Button>().onClick.AddListener(() =>
            {
                id = u;
                preview.sprite = platformTiles[u].sprite;
            });
            t.SetActive(false);
            platforms[i] = t;
        }
    }
    private void InstantiateEnemies()
    {
        enemies = new GameObject[10];
        for (int i = 0; i < enemiesTiles.Length; i++)
        {
            int u = i;
            var t = Instantiate(buttonPrefab, layout);
            t.GetComponent<Image>().sprite = enemiesTiles[u].sprite;
            t.GetComponent<Button>().onClick.AddListener(() =>
            {
                id = u;
                preview.sprite = enemiesTiles[u].sprite;
            });
            t.SetActive(false);
            enemies[i] = t;
        }
    }
    
    public void ShowTilesMenu(bool bo)
    {
        foreach(GameObject gm in tilesSet)
        {
            if (gm != null)
            {
                gm.SetActive(bo);
            }
        }
        if (bo)
        {
            currentMenu = "tiles";
            ShowMainMenu(!bo);
            //ShowTilesMenu(bo);
            ShowPlayerMenu(!bo);
            ShowPlatformMenu(!bo);
            ShowEnemyMenu(!bo);
            showBackButton(bo);
        }
        
        
    }
    public void ShowPlayerMenu(bool bo)
    {
        foreach (GameObject gm in players)
        {
            if (gm != null)
            {
                gm.SetActive(bo);
            }
        }
        if (bo)
        {
            currentMenu = "players";
            ShowMainMenu(!bo);
            ShowTilesMenu(!bo);
            //ShowPlayerMenu(!bo);
            ShowPlatformMenu(!bo);
            ShowEnemyMenu(!bo);
            showBackButton(bo);
        }
    }
    public void ShowEnemyMenu(bool bo)
    {
        foreach (GameObject gm in enemies)
        {
            if (gm != null)
            {
                gm.SetActive(bo);
            }
        }
        if (bo)
        {
            currentMenu = "platforms";
            ShowMainMenu(!bo);
            ShowTilesMenu(!bo);
            ShowPlayerMenu(!bo);
            ShowPlatformMenu(!bo);
            //ShowEnemyMenu(!bo);
            showBackButton(bo);
        }
        
    }
    public void ShowPlatformMenu(bool bo)
    {
        foreach (GameObject gm in platforms)
        {
            if (gm != null)
            {
                gm.SetActive(bo);
            }
        }
        if (bo)
        {
            currentMenu = "enemies";
            ShowMainMenu(!bo);
            ShowTilesMenu(!bo);
            ShowPlayerMenu(!bo);
            //ShowPlatformMenu(!bo);
            ShowEnemyMenu(!bo);
            showBackButton(bo);
        }
        
    }
    public void ShowMainMenu(bool bo)
    {
        foreach (GameObject gm in mainMenu)
        {
            if (gm != null)
            {
                gm.SetActive(bo);
            }
        }
        if (bo)
        {
            //ShowMainMenu(!bo);
            ShowTilesMenu(!bo);
            ShowPlayerMenu(!bo);
            ShowPlatformMenu(!bo);
            ShowEnemyMenu(!bo);
            showBackButton(!bo);
        }
        
    }
    
    public void showBackButton(bool bo)
    {
        backButton.SetActive(bo);
    }
   
    public void changeBackground()
    {
        currentBackground++;
        switch (currentBackground)
        {
            case 0:
                background.GetComponent<SpriteRenderer>().sprite = bgSprites[0];
                break;
            case 1:
                background.GetComponent<SpriteRenderer>().sprite = bgSprites[1];
                break;
            case 2:
                background.GetComponent<SpriteRenderer>().sprite = bgSprites[2];
                break;
            case 3:
                background.GetComponent<SpriteRenderer>().sprite = bgSprites[3];
                currentBackground = -1;
                break;

        }
    }
    public void TogglePlaying()
    {
        playing = !playing;
        preview.enabled = !playing;
        
        for (int i = 0; i < playingObjects.Length; i++)
        {
            playingObjects[i].SetActive(!playing);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            return;
        if (playing)
            return;

        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        pos.x = Mathf.RoundToInt(pos.x);
        pos.y = Mathf.RoundToInt(pos.y);

        preview.transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var c = Physics2D.CircleCast(pos, 0.4f, Vector2.zero);
            if (c.collider == null)
            {
                switch (currentMenu)
                {
                    case "tiles":
                        Instantiate(tiles[id].gameObject, pos, Quaternion.identity);
                        break;
                    case "players":
                        Instantiate(playersTiles[id].gameObject, pos, Quaternion.identity);
                        break;
                    case "platforms":
                        Instantiate(platformTiles[id].gameObject, pos, Quaternion.identity);
                        break;
                    case "enemies":
                        Instantiate(enemiesTiles[id].gameObject, pos, Quaternion.identity);
                        break;
                }
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            var c = Physics2D.CircleCast(pos, 0.4f, Vector2.zero);
            if (c.collider != null)
            {
                Destroy(c.collider.gameObject);
            }
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(pos, 0.4f);
    }
}
