using System;

namespace IGS.Fuzzy.Examples.EmployeeDistribution.Presenter
{
    public class Post : IEquatable<Post>
    {
        public Post(string name)
        {
            Name = name;
        }
        
        public string Name { get; private set; }
        
        public bool Equals(Post other)
        {
            return Name.Equals(other.Name);
        }
    }
}