using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twilio.AspNet.Common;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;

namespace wspbot.Controllers
{
    public class WhatsAppController : TwilioController
    {

        public TwiMLResult Index(SmsRequest IncomingMessage) {

      
            
            var MessagingResponse = new MessagingResponse();
            var requestBody = Request.Form["Body"];

            if (requestBody == "hola")
            {

                MessagingResponse.Message($"Hola, esta es la demo del bot QA");
                MessagingResponse.Message($"Ingrese su DNI: ");
                var dni = IncomingMessage.Body;
                var url = $"https://dniruc.apisperu.com/api/v1/dni/{dni}?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImNhcmxvcmQ1MjcyMDA5QGdtYWlsLmNvbSJ9.l_yRWYZ5sR1-ttVmd3LOSJfGI8T2kf2UeqjhCedACa0";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null)
                            {

                                MessagingResponse.Message($"DNI no valido");
                            }

                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();

                                MessagingResponse.Message("Hola: ");
                                MessagingResponse.Message(responseBody);


                            }
                        }
                    }
                }
                catch (WebException ex)
                {

                }

            }
            else if (requestBody == "1")
            {
                MessagingResponse.Message("​El Sistema Privado de Pensiones: Fue creado en 1992, mediante Decreto Ley N° 27897, a través del cual el afiliado cotiza una contribución definida a una cuenta individual de capitalización(CIC), que es administrada por las AFP'S, con el objeto de acumular un fondo pensionario individual y gozarlo al momento de su cese laboral. ");
            }
            else if (requestBody == "2") {

                MessagingResponse.Message("Es el Régimen Especial Pesquero, regulado por la Ley N° 30003 y que es administrado por la Oficina de Normalización Previsional – ONP. Este régimen tiene en cuenta la estacionalidad y el riesgo propio de la actividad pesquera en el país, así como los aportes que efectúen los trabajadores pesqueros y armadores.​");
            }
            else if (requestBody == "3") {

                MessagingResponse.Message("1. Pensión de Renta Vitalicia por Accidente de Trabajo.​");
                MessagingResponse.Message("2. Pensión de Renta Vitalicia por Enfermedad Profesional.");
                MessagingResponse.Message("3. Indemnización por Accidente de Trabajo.");
                MessagingResponse.Message("4. Indemnización por Enfermedad Profesional.");
                MessagingResponse.Message("5. Pensión de Viudez (cónyuge).");
                MessagingResponse.Message("6. Pensión de Orfandad (hijos).");
                MessagingResponse.Message("7. Pensión de Ascendientes (padres).​​");
            }
            else
            {

                MessagingResponse.Message("Elija una opcion: ");
                MessagingResponse.Message("1. ¿Cuáles son " +
                    "los principales sistemas de pensiones que existen en el Perú? ");

                MessagingResponse.Message("2. ¿Qué es el REP?");

                MessagingResponse.Message("3. ¿Cuántos tipos de Prestaciones ofrece el D.L. N°18846?");
            }

            return TwiML(MessagingResponse);
        }

    }
}
