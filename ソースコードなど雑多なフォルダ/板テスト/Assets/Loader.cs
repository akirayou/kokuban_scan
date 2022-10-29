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
    /// ¶‚Ü‚ê‚½”
    /// </summary>
    private int count;
    void Start()
    {
        string backFile=in_dir + @"\..\”wŒi\”wŒi.jpg";

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
            Debug.LogError("”wŒiƒtƒ@ƒCƒ‹‚ª‚È‚¢‚Ì‚Å–³‹");
        }
        catch (FileLoadException)
        {
            Debug.LogError("ƒtƒ@ƒCƒ‹‚ª“Ç‚İ‚ß‚È‚©‚Á‚½");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.realtimeSinceStartup;
        if ( now - lastTime < span) return;//˜A‘±‚µ‚Ä¶‚Ü‚ê‚é‚Ì‚Í‘j~

        string[] files = System.IO.Directory.GetFiles(in_dir, "*.png", System.IO.SearchOption.TopDirectoryOnly);
        if (files.Length > 0)
        {
            lastTime = Time.realtimeSinceStartup;//˜A‘±‚µ‚Ä¶‚Ü‚ê‚é‚Ì‚Í‘j~

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
            File.Delete(file);//ã‘‚«‚ÉŒ³ƒtƒ@ƒCƒ‹‚ğÁ‚³‚È‚¢‚Ì‚ÅA”O‚Ì‚½‚ßíœ

            
        }
    }
}
