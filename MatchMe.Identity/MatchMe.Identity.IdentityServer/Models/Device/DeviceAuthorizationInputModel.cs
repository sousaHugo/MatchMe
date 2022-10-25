// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using MatchMe.Identity.IdentityServer.Models.Consent;

namespace MatchMe.Identity.IdentityServer.Models.Device
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}