using System;
using System.Collections.Generic;
using System.Text;

namespace Legal.Test
{
    public class Startup
    {
        public Startup()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }
    }
}
