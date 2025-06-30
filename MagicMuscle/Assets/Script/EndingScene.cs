using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


public class GameTimer : MonoBehaviour
    {
        public float gameTime = 60f; // ゲームの制限時間（秒）
        public Text timerText;       // UI に残り時間を表示（オプション）

        private bool gameEnded = false;

        void Update()
        {
            if (gameEnded) return;

            gameTime -= Time.deltaTime;

            if (timerText != null)
            {
                timerText.text = Mathf.Ceil(gameTime).ToString("00");
            }

            if (gameTime <= 0f)
            {
                gameEnded = true;
                EndGame();
            }
        }

        void EndGame()
        {
            SceneManager.LoadScene("EndingScene");
        }
    }
    
    public class EndingManager : MonoBehaviour
{
    public Image characterImage;      // 先輩魔法少女のイラスト表示
    public Text messageText;          // セリフ表示（TextMeshProUGUIでもOK）

    // 仮スコア（本番ではGameManagerなどから取得）
    private int finalScore;

    void Start()
    {
        // スコアの取得（例：PlayerPrefsやシングルトン経由）
        finalScore = PlayerPrefs.GetInt("FinalScore", 0);

        ShowEnding(finalScore);
    }

    void ShowEnding(int score)
    {
       string imageName = "";  // 後で「表示する画像のパス」を入れる変数
       string message = "";    // 後で「表示するセリフ」を入れる変数

        if (score < 200)
        {
            imageName = "Endings/fail_01";
            message = "いい感じね！　この調子で頑張りましょう！”;
        }
        else if (score < 400)
        {
            imageName = "Endings/fail_02";
            message = "あらやだイケメン･･････どうして？”;
        }
        else if (score < 600)
        {
            imageName = "Endings/neutral";
            message = "かなり逞しくなったわね。･･････うん。なんか、スゴイ！”;
        }
        else if (score < 800)
        {
            imageName = "Endings/good";
            message = “・・・・・・頼もしいんだけど、なんか怖い”;
        }
        else
        {
            imageName = "Endings/great";
            message = "イギャアアアアアアアアアアア！！　バケモノオオオオオオ！！”;
        }

        // Resources から画像を読み込み
        Sprite loadedSprite = Resources.Load<Sprite>(imageName);
        if (loadedSprite != null)
        {
            characterImage.sprite = loadedSprite;
        }
        else
        {
            Debug.LogWarning("イラストが見つかりません: " + imageName);
        }

        // セリフを表示
        messageText.text = message;
    }
}


        
    }

    // Update is called once per frame