using RestSharp;

namespace mascotePokemon.Modelos;

internal class MethodGET
{
    public static RestResponse RequisicaoGet(string url)
    {
        var client = new RestClient(url);
        RestRequest restRequest = new("", Method.Get);
        var response = client.Execute(restRequest);
        return response;
    }
}
