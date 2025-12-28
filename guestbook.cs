using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace posts
{
    public class Guestbook
    {
        //lists and json-file
        private string fileName = @"guestbook.json";

        private List<Post> posts = new List<Post>();

        public Guestbook()
        {
            //get the data from the file if there is any data there to retrieve
            if(File.Exists(fileName) == true)
            {
                string jsonString = File.ReadAllText(fileName);
                posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!;
            }
        }

        //create new post and owner
        public Post addPost(string p_t, string p_o)
        {
            Post obj = new Post();
            obj.PostText = p_t;
            obj.PostOwner = p_o;

            posts.Add(obj);
            Marshal();

            return obj;
        }

        //remove post and owner
        public int deletePost(int index)
        {
            posts.RemoveAt(index);
            Marshal();

            return index;
        }

        //get posts and owners
        public List<Post> GetPosts()
        {
            return posts;
        }

        //serialize objects and save to file
        private void Marshal()
        {
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(fileName, jsonString);
        }
    }
}