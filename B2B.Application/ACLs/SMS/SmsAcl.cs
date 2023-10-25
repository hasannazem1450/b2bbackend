using B2B.Application.Contracts.ACLs.Sms;
using B2B.Application.Contracts.ACLs.Sms.Models;
using B2B.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace B2B.Application.ACLs.SMS;

public class SmsAcl : ISmsAcl
{
    private readonly SmsSetting _smsSetting;

    public SmsAcl(IOptions<SmsSetting> smsOptions)
    {
        _smsSetting = smsOptions.Value;
    }

    public async Task<SmsAclOutputModel> Send(SmsAclInputModel model)
    {
        var client = new RestClient(_smsSetting.BaseUrl);
        client.Authenticator =
            new HttpBasicAuthenticator(_smsSetting.Username + "/" + _smsSetting.Domain, _smsSetting.Password);

        var request = new RestRequest(_smsSetting.ResourceUrl, Method.Post);

        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("accept", "application/json");

        request.AddParameter("senders", _smsSetting.Sender);
        request.AddParameter("messages", model.Message);
        request.AddParameter("recipients", model.Receiver);

        var response = await client.ExecuteAsync(request);
        var responseModel = JsonConvert.DeserializeObject<SendResponseModel>(response.Content ?? "");

        return new SmsAclOutputModel
            {IsSuccess = response.IsSuccessful && responseModel.status == _smsSetting.SuccessCode};
    }

    internal class SendResponseModel
    {
        public int status { get; set; }
        public List<object> messages { get; set; }
    }
}