using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialMediaPostManagement
{
    // User class
    class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public int FollowersCount { get; set; }
        public List<string> Following { get; set; }

        public User()
        {
            Following = new List<string>();
        }
    }

    // Post class
    class Post
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public string PostType { get; set; } // Text / Image / Video
        public int Likes { get; set; }
        public List<string> Comments { get; set; }

        public Post()
        {
            Comments = new List<string>();
        }
    }

    // SocialMediaManager class
    class SocialMediaManager
    {
        private List<User> users = new List<User>();
        private List<Post> posts = new List<Post>();

        private int userCounter = 1;
        private int postCounter = 1;

        // Register user
        public void RegisterUser(string userName, string bio)
        {
            User user = new User
            {
                UserId = "U" + userCounter++,
                UserName = userName,
                Bio = bio,
                FollowersCount = 0
            };

            users.Add(user);
            Console.WriteLine("User registered successfully");
        }

        // Create post
        public void CreatePost(string userId, string content, string type)
        {
            Post post = new Post
            {
                PostId = "P" + postCounter++,
                UserId = userId,
                Content = content,
                PostType = type,
                PostTime = DateTime.Now,
                Likes = 0
            };

            posts.Add(post);
            Console.WriteLine("Post created successfully");
        }

        // Like a post
        public void LikePost(string postId, string userId)
        {
            Post post = posts.FirstOrDefault(p => p.PostId == postId);
            if (post != null)
                post.Likes++;
        }

        // Add comment
        public void AddComment(string postId, string userId, string comment)
        {
            Post post = posts.FirstOrDefault(p => p.PostId == postId);
            if (post != null)
                post.Comments.Add(userId + ": " + comment);
        }

        // Group posts by user
        public Dictionary<string, List<Post>> GroupPostsByUser()
        {
            return posts
                .GroupBy(p => p.UserId)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get trending posts
        public List<Post> GetTrendingPosts(int minLikes)
        {
            return posts
                .Where(p => p.Likes >= minLikes)
                .OrderByDescending(p => p.Likes)
                .ToList();
        }
    }

    // Program class
    class Program
    {
        static void Main()
        {
            SocialMediaManager manager = new SocialMediaManager();

            // Register users
            manager.RegisterUser("Ravi", "Tech enthusiast");
            manager.RegisterUser("Anita", "Travel blogger");

            // Create posts
            manager.CreatePost("U1", "Hello World!", "Text");
            manager.CreatePost("U2", "My travel vlog", "Video");

            // Like posts
            manager.LikePost("P1", "U2");
            manager.LikePost("P1", "U2");
            manager.LikePost("P2", "U1");

            // Add comments
            manager.AddComment("P1", "U2", "Nice post!");
            manager.AddComment("P2", "U1", "Great video!");

            // Group posts by user
            Console.WriteLine("\nPosts Grouped By User:");
            var grouped = manager.GroupPostsByUser();
            foreach (var group in grouped)
            {
                Console.WriteLine(group.Key);
                foreach (var post in group.Value)
                    Console.WriteLine(post.Content);
            }

            // Trending posts
            Console.WriteLine("\nTrending Posts:");
            var trending = manager.GetTrendingPosts(2);
            foreach (var post in trending)
                Console.WriteLine(post.PostId + " Likes: " + post.Likes);
        }
    }
}
