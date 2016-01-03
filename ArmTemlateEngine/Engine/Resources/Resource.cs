namespace ArmTemlateEngine.Engine.Resources
{
    public class Resource 
    {
        public Resource(string resourceType)
        {
            type = resourceType;
        }
        public string type { get; }
        public string name { get; set; }
        public string apiVersion { get; set; }
        public string location { get; set; }

        public dynamic properties { get; set; }
    }
}
