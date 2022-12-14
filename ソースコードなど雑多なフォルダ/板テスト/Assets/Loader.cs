using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Loader : MonoBehaviour
{
 

    // Start is called before the first frame update
    public string in_dir = @"C:\Users\youak\Documents\Python Scripts\to_unity";
    public float span = 10;
    public float lastTime = 0;
    public GameObject[] prefabs;
    public GameObject backGround;
    /// <summary>
    /// 生まれた数
    /// </summary>
    private int count;
    void Start()
    {
        string backFile=in_dir + @"\..\背景\背景.jpg";

        lastTime = -1000;
        count = 0;
        try
        {
            var rend = backGround.GetComponentInChildren<Renderer>();
            byte[] bytes = File.ReadAllBytes(backFile);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(bytes);
            rend.material.mainTexture = texture;
        }
        catch (FileNotFoundException e)
        {
            Debug.LogError("背景ファイルがないので無視");
        }
        catch (FileLoadException)
        {
            Debug.LogError("ファイルが読み込めなかった");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.realtimeSinceStartup;
        if ( now - lastTime < span) return;//連続して生まれるのは阻止

        string[] files = System.IO.Directory.GetFiles(in_dir, "*.png", System.IO.SearchOption.TopDirectoryOnly);
        if (files.Length > 0)
        {
            lastTime = Time.realtimeSinceStartup;//連続して生まれるのは阻止

            count++;
            string file = files[0];

            int id = int.Parse(Path.GetFileName(file).Substring(0, 1));
            if (0 <= id || prefabs.Length < id)
            {
                var a = Instantiate(prefabs[id]);
                int pos = 0;
                if ((count & 0x01) != 0) pos += 16;
                if ((count & 0x02) != 0) pos += 8;
                if ((count & 0x04) != 0) pos += 4;
                if ((count & 0x08) != 0) pos += 2;
                if ((count & 0x10) != 0) pos += 1;

                a.transform.Translate(Vector3.forward * (0.1f * pos)  );
                Debug.Log(a.transform);
                var move = a.GetComponentInChildren<MoveBase>();
                move.Seed = count;


                Debug.Log(file);
                byte[] bytes = File.ReadAllBytes(file);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(bytes);

                move.SeTexture(texture);

                a.transform.parent = this.transform;
            }
            string used_path=Path.GetDirectoryName(file) + @"\used\" +id.ToString()+"_"+count.ToString()+"_"+Path.GetFileName(file);
            File.Move(file, used_path);
            File.Delete(file);//上書き時に元ファイルを消さないので、念のため削除

            
        }
    }
}
