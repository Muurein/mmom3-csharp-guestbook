using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace posts
{
    public class Guestbook
    {
        //listor och json-fil
        private string fileName = @"guestbook.json";

        private List<Post> posts = new List<Post>();

        public Guestbook()
        {
            //hämtar datan från filen om det finns någon data att hämta
            if(File.Exists(fileName) == true)
            {
                string jsonString = File.ReadAllText(fileName);
                posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!;
            }
        }

        //skapar ett nytt inlägg och en ny ägare
        public Post addPost(string p_t, string p_o)
        {
            Post obj = new Post();
            obj.PostText = p_t;
            obj.PostOwner = p_o;

            posts.Add(obj);
            Marshal();

            return obj;
        }

        //tar bort inlägg samt ägare
        public int deletePost(int index)
        {
            posts.RemoveAt(index);
            Marshal();

            return index;
        }

        //hämtar inlägg och ägare
        public List<Post> GetPosts()
        {
            return posts;
        }

        //serialiserar object och sparar ner dem till filen
        private void Marshal()
        {
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(fileName, jsonString);
        }
    }
}