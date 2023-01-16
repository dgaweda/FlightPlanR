﻿using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace FlightPlanApi.Authentication;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
  public BasicAuthenticationHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options, 
    ILoggerFactory logger, 
    UrlEncoder encoder, 
    ISystemClock clock) 
    : base(options, logger, encoder, clock)
  {
  }

  protected override Task<AuthenticateResult> HandleAuthenticateAsync()
  {
    throw new NotImplementedException();
  }
}