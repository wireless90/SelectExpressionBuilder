namespace SelectExpressionBuilder.Core.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node();
            root.Add("Id")
                .Add("PNames[Name]")
                .Add("PName.Name")
                .Add("PNames[Id]")
                .Add("Gender")
                .Add("PName.Id");


            ViewModelBuilder queryBuilder = new ViewModelBuilder();
            string selectQuery = queryBuilder.Build(root);
        }
    }
}
