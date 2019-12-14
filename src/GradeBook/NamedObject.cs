namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(string name) => Name = name;
        public string Name
        {
            get;
            private set;  // Can only set it from inside Book.cs code
        }
    }
};