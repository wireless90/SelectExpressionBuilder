using System.Linq;
using System.Text;

namespace SelectExpressionBuilder.Core
{
    public class ViewModelBuilder
    {
        public string Build(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node.Type == Node.NodeType.ROOT) //root node
            {
                foreach (var childNode in node.ChildNodes)
                {
                    string build = Build(childNode);
                    sb.Append(build);
                }

                string build2 = sb.ToString();
                build2 = build2.Take(build2.Length - 1).ToString();
                string ret = $"new {{ {build2 } }}";
                return ret;
            }
            else if (node.Type == Node.NodeType.PROPERTY) // leaf node
            {
                string ret = $"{node.Projection.PropertyId} as {node.Projection.DisplayName},";
                return ret;
            }
            else if (node.Type == Node.NodeType.OBJECT) 
            {
                foreach (var childNode in node.ChildNodes)
                {
                    string build = Build(childNode);
                    build = $"{node.Projection.DisplayName}.{build}";
                    sb.Append(build);
                }

                string build2 = sb.ToString();
                build2 = build2.Take(build2.Length - 1).ToString();
                string ret = $"new {{ { build2} }} as {node.Projection.DisplayName},";
                return ret;
            }
            else
            {
                foreach (var childNode in node.ChildNodes)
                {
                    string build = Build(childNode);
                    build = $"{build}";
                    sb.Append(build);
                }

                string build2 = sb.ToString();
                build2 = build2.Take(build2.Length - 1).ToString();
                string ret = $"{node.Projection.DisplayName}.Select(new {{ {build2} }}) as {node.Projection.DisplayName},";
                return ret;
            }
        }
    }
}
