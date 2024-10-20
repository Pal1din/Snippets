using Grpc.Core;
using LeetCodeGrpcServer;
using Microsoft.AspNetCore.Authorization;
using RestSharp;

namespace Backend.Services;

[Authorize]
public class LeetcodeService(IRestClient client) : LeetCodeService.LeetCodeServiceBase
{
    public override async Task<GetProfileResponse> GetProfile(GetProfileRequest request, ServerCallContext context)
    {
        var restRequest = new RestRequest(request.Username);
        var executeAsync = await client.ExecuteAsync(restRequest);
        var profile = Profile.Parser.ParseJson(executeAsync.Content);
        var result = new GetProfileResponse
        {
            Profile = { profile }
        };
        return result;
    }

    public override async Task GetProfileList(GetProfileListRequest request,
        IServerStreamWriter<GetProfileResponse> responseStream, ServerCallContext context)
    {
        foreach (var username in request.Username)
        {
            var restRequest = new RestRequest(username);
            var executeAsync = await client.ExecuteAsync(restRequest);
            var profile = Profile.Parser.ParseJson(executeAsync.Content);
            var result = new GetProfileResponse
            {
                Profile = { profile }
            };
            await responseStream.WriteAsync(result);
        }
    }

    public override async Task<GetSolvedResponse> GetSolved(GetProfileRequest request, ServerCallContext context)
    {
        var restRequest = new RestRequest($"{request.Username}/solved");
        var executeAsync = await client.ExecuteAsync(restRequest);
        var solved = Solved.Parser.ParseJson(executeAsync.Content);
        var result = new GetSolvedResponse
        {
            Solved = { solved }
        };
        return result;
    }

    public override async Task<GetCalendarResponse> GetCalendar(GetProfileRequest request, ServerCallContext context)
    {
        var restRequest = new RestRequest($"{request.Username}/calendar");
        var executeAsync = await client.ExecuteAsync(restRequest);
        var calendar = Calendar.Parser.ParseJson(executeAsync.Content);
        var result = new GetCalendarResponse
        {
            Calendar = { calendar }
        };
        return result;
    }

    public override async Task<GetSkillStatsResponse> GetSkillStats(GetProfileRequest request,
        ServerCallContext context)
    {
        var restRequest = new RestRequest($"skillStats/{request.Username}");
        var executeAsync = await client.ExecuteAsync(restRequest);
        var skillStats = SkillStats.Parser.ParseJson(executeAsync.Content);
        var result = new GetSkillStatsResponse
        {
            SkillStats = { skillStats }
        };
        return result;
    }

    public override async Task<GetLanguageStatsResponse> GetLanguageStats(GetProfileRequest request,
        ServerCallContext context)
    {
        var restRequest = new RestRequest($"languageStats");
        restRequest.AddQueryParameter("username", request.Username);
        var executeAsync = await client.ExecuteAsync(restRequest);
        var languageStats = LanguageStats.Parser.ParseJson(executeAsync.Content);
        var result = new GetLanguageStatsResponse
        {
            LanguageStats = { languageStats }
        };
        return result;
    }
}