/*
    Ett program där användaren kan lägga till, ta bort eller visa alla inlägg i en gästbok genom ett enkelt menysystem. Varje inlägg har en ägare.
    
    Skapad av Amanda Thim
    med hjälp av det lärarledda materialet
*/

using System;
using System.Runtime.CompilerServices;

namespace posts
{
    class Program
    {
        static void Main(string[] args)
        {
            Guestbook guestbook = new Guestbook();
            int i = 0;

            while(true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("Gästbok\n\n");

                Console.WriteLine("1. Skriv ett inlägg i gästboken");
                Console.WriteLine("2. Ta bort ett inlägg ur gästboken\n");
                Console.WriteLine("X. Avsluta\n");

                i = 0;

                foreach(Post post in guestbook.GetPosts()) {
                    //Console.WriteLine("[" + i++ + "]" + post.PostText);
                    Console.WriteLine($"[{ i++ }] {post.PostText} (av: {post.PostOwner})");
                }


                int input = (int) Console.ReadKey(true).Key;

                switch (input)
                {
                    case '1':
                        Console.CursorVisible = true;

                        Console.Write("Skriv ditt inlägg: "); 
                        string? postText = Console.ReadLine();
                        
                        Console.Write("Skriv in ditt namn: "); 
                        string? postOwner = Console.ReadLine();

                        if(string.IsNullOrEmpty(postText) || string.IsNullOrEmpty(postOwner))
                        {
                            Console.WriteLine("\nDu måste både skriva ett inlägg och fylla i ditt namn. Tryck på valfri knapp för att fortsätta.");
                            Console.ReadKey();
                        } else
                        {
                            guestbook.addPost(postText, postOwner);
                            
                            Console.WriteLine("Inlägget har registrerats! Tryck på valfri knapp för att fortsätta.");
                            Console.ReadKey();
                        }
                        
                        break;
                    case '2':
                        Console.CursorVisible = true;
                        Console.Write("Vilket index vill du radera?");
                        string? index = Console.ReadLine();

                        if(!String.IsNullOrEmpty(index))
                        {
                            try
                            {
                                guestbook.deletePost(Convert.ToInt32(index));
                            }
                            catch
                            {
                                Console.WriteLine("Indexet stämmer inte.\n Klicka på valfri knapp för att gå vidare.");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 88:
                        Environment.Exit(0);
                        break;
                }

            }
        }
    }
}