using System.Net;
using Grpc.Core;
using IdentityServer;
using Microsoft.AspNetCore.Authorization;
using RestSharp;

namespace Backend.Services;

public class AuthorizationService(IConfiguration configuration) : IdentityServer.AuthorizationService.AuthorizationServiceBase
{
    public override async Task<GetTokenResponse> GetToken(GetTokenRequest request, ServerCallContext context)
    {
        var s = configuration.GetConnectionString("IdentityServer") ?? "identityserver";
        var client = new RestClient(s, options =>
        {
            options.RemoteCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
        });
        var apirequest = new RestRequest("/connect/token", Method.Post);
        apirequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        apirequest.AddParameter("client_id", "grpc_client");
        apirequest.AddParameter("client_secret", "grpc_secret");
        apirequest.AddParameter("grant_type", "client_credentials");
        RestResponse response = await client.ExecuteAsync(apirequest);
        var content = response.Content;
        return GetTokenResponse.Parser.ParseJson(content);
    }
}