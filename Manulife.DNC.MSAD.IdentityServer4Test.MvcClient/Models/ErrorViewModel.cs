using System;

namespace Manulife.DNC.MSAD.IdentityServer4Test.MvcClient.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}