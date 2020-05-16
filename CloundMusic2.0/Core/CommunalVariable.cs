using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloundMusic2._0.Core
{
    public class CommunalVariable
    {
        private string testCurrentUser;
        public string TestCurrentUser
        {
            get { return this.testCurrentUser; }
            set
            {
                if (this.testCurrentUser != value)
                {
                    this.testCurrentUser = value;
                }
            }
        }
    }
}
