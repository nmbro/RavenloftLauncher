
namespace NWNBrowser
{
    public class Repository
    {
        private string address;
        private string description;

        public Repository(string addr, string desc)
        {
            this.address = addr;
            this.description = desc;
        }

        public string Address
        {
            get
            {
                return this.address;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }
    }
}
