using UnityEngine;
using System.IO;
public class StatusManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTextFile(int score)
    {
        
        int highScore = 0;
        string path = Application.dataPath + "/Resources/Status.txt";
        if(File.Exists(path))
        {
            using (var fs = new StreamReader(path, System.Text.Encoding.GetEncoding("UTF-8")))
            {
                string beforeScore = fs.ReadLine();
                highScore = int.Parse(beforeScore);
                if(highScore < score)
                {
                    highScore = score;//ファイルがある＆＆最新スコア
                }
                
            }
        }
        else
        {
            using(StreamWriter fs = new StreamWriter(path, false))
            {
                fs.WriteLine(score);//ファイルが無い＝＝今回がハイスコア
                fs.Flush();

            }
            
        }
        
    }
}
