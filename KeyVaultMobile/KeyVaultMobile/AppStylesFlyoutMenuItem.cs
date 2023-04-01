using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyVaultMobile
{

    public class AppStylesFlyoutMenuItem
    {
        public AppStylesFlyoutMenuItem()
        {
            TargetType = typeof(AppStylesFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}