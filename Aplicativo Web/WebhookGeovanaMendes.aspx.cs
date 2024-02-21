using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicativo_Web
{
    public partial class WebhookGeovanaMendes : System.Web.UI.Page
    {
        private string erro;

        protected async void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Request.InputStream.Position = 0;

                //lê os dados brutos da requisição
                string requestbody = new StreamReader(Request.InputStream).ReadToEnd();

            //verifica se os dados são nulos ou vazios
            if (!string.IsNullOrEmpty(requestbody))
            {
                //converte json em objeto
                JObject respWebHookJsonObject = JObject.Parse(requestbody);

                string APIurl = "http://receptor.com/api/endpoint";

                using (var httpCliente = new HttpClient())
                {
                    HttpResponseMessage response = await httpCliente.PostAsync(APIurl, respWebHookJsonObject);
                }
            }

        }
            catch (Exception erro)
            {
                Console.WriteLine("Falha! Ocorreu o seguinte erro:  " + erro);
            }
        }
    }

   
}