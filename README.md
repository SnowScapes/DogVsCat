# 🐶 내일배움캠프 사전캠프 3주차 <img src="https://img.shields.io/badge/Unity-FFFFFF?style=flat&logo=Unity&logoColor=5D5D5D"/> <img src="https://img.shields.io/badge/C%23-5D5D5D?style=flat&logo=csharp&logoColor=FFFFFF"/>   
## 🖥 개발환경    

* CPU : I7-13700K 3.40Ghz    
* RAM : DDR4 64GB 3800Mhz    
* VGA : NVIDIA RTX 3090 GDDR6X 24GB    
* OS : MICROSOFT WINDOWS 11    
* Engine : UNITY 2021.3.16f1    
* IDE : MICROSOFT Visual Studio 2022    

## 🐱 고양이 밥주기    
<img src="/IMGS/Game.gif" width="50%" height="50%" title="game" alt="Game"></img>    
#### 고양이에게 밥을 주어 가게에 오지 못하도록 막는 게임    
> ##### 🎮 게임 플레이
> 1. 게임이 시작되면 위에서 고양이들이 오기 시작한다.    
> 2. 강아지 사장님을 마우스로 움직여 고양이들에게 먹이를 줄 수 있다.    
> 3. 고양이들은 일정 개수의 먹으면 만족하며 사라진다.  
> 4. 고양이들을 만족시킨만큼 레벨이 오르며, 레벨에 따라 뚱뚱한 고양이 혹은 해적 고양이가 나오기도 한다.
> 5. 최대한 많은 고양이들을 만족시켜보자.

## 🔑 기존 코드
<details><summary><b>접기/펼치기</b></summary>

<details><summary><b>GameManager.cs</b></summary>

```csharp
public class Cat : MonoBehaviour
{
    public Transform front;
    public GameObject hungryCat;
    public GameObject fullCat;

    public int type;
    float speed;
    float full;
    float energy = 0.0f;
    bool isFull = false;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector2(x, y);

        if (type == 1)
        {
            speed = 0.05f;
            full = 5f;
        }
        else if (type == 2)
        {
            speed = 0.02f;
            full = 10f;
        }
        else if (type == 3)
        {
            speed = 0.1f;
            full = 5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed;

        if (energy < full)
        {
            transform.position += Vector3.down * speed;

            if (transform.position.y < -16.0f)
            {
                GameManager.Instance.GameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += Vector3.right * 0.05f;
            }
            else
            {
                transform.position += Vector3.left * 0.05f;
            }
            Destroy(gameObject, 3.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {
                energy += 1.0f;
                Destroy(collision.gameObject);
                front.localScale = new Vector3(energy / full, 1.0f, 1.0f);

                if (energy == 5.0f)
                {
                    if (!isFull)
                    {
                        isFull = true;
                        hungryCat.SetActive(false);
                        fullCat.SetActive(true);
                        GameManager.Instance.AddScore();
                        Destroy(gameObject, 3.0f);
                    }
                }
            }
        }
    }
}
```

</details>

</details>
