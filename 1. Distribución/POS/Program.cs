using POSEntity;
using System.Net;
using System.Net.Http.Headers;

char readOption;
TransaccionPOSBE transaccion;
string token;

Console.SetWindowSize(30, 20);
Console.Title = "POS";
Welcome();

do
{
    WriteMenu();
    readOption = Console.ReadKey().KeyChar;
    switch (readOption)
    {
        case '1':
            Console.Clear();
            token = authentication();
            transaccion = IngresarDatos();
            EscribeTransaccion(transaccion, token);
            break;
        case '0':
            Console.WriteLine("\nSalir");
            _ = Console.ReadKey().KeyChar;
            break;
        default:
            Console.WriteLine("\nOpción no valida...");
            _ = Console.ReadKey().KeyChar;
            break;
    }
    Thread.Sleep(2000);
    Console.Clear();
} while (readOption != '0');


void Welcome()
{
    LoadLine("\n\nBienvenido de vuelta\n", 100);
    LoadLine("\n\nCargando el sistema...\n", 100);
    LoadLine("\n\n  0%  |--------------------| ", 300);
    LoadLine("\r 10 % |**------------------| ", 300);
    LoadLine("\r 20 % |****----------------| ", 300);
    LoadLine("\r 30 % |******--------------| ", 300);
    LoadLine("\r 40 % |********------------| ", 300);
    LoadLine("\r 50 % |**********----------| ", 300);
    LoadLine("\r 60 % |************--------| ", 300);
    LoadLine("\r 70 % |**************------| ", 300);
    LoadLine("\r 80 % |****************----| ", 300);
    LoadLine("\r 90 % |******************--| ", 300);
    LoadLine("\r100 % |********************| ", 300);
    Thread.Sleep(2000);
    Console.Clear();
}

void LoadLine(string text, int time)
{
    Thread.Sleep(time);
    Console.Write(text);
}

void WriteMenu(){
    Console.WriteLine("\n\nMenú de Operaciones");
    Console.WriteLine("\n1. Realizar venta");
    Console.WriteLine("0. Salir");
    Console.Write("Ingrese una opción: ");
}

string? ReadInput(string title, string errorMessage)
{
    Console.WriteLine(title);
    string inputString = Console.ReadLine();
    if (inputString == null)
    {
        Console.WriteLine(errorMessage);
        return null;
    }
    return inputString;
}

string Input(string title, string errorMessage, string? text)
{
    string Input;
    do
    {
        Console.Clear();
        if(text != null)
        {
            Console.WriteLine(text);
        }
        Input = ReadInput(title, errorMessage);
    } while (Input == null || Input == "");
    return Input;
}

TransaccionPOSBE IngresarDatos()
{
    TransaccionPOSBE transaccion = new TransaccionPOSBE();
    string Monto = Input("Ingresar Monto:", "\n\nEl monto ingresado no es correcto...", null);
    transaccion.NumeroTarjeta = Input("\nIngresar numero de tarjeta: ", "\n\nDebe ingresar un numero de tarjeta...", "Ingresar Monto:\n" + Monto);
    transaccion.PIN = Input("\nIngresar PIN:", "\n\nDebe ingresar un PIN valido...", "Ingresar Monto:\n" + Monto + "\n\nIngresar numero de tarjeta: \n" + transaccion.NumeroTarjeta);
    transaccion.Monto = Convert.ToDouble(Monto);
    return transaccion;
}

void EscribeTransaccion(TransaccionPOSBE transaccion, string token)
{
    var method = HttpMethod.Post;
    Uri uri = new Uri("https://apiposv120220718002121.azurewebsites.net/pos/api/v1/POS");
    string body = "{\n \"numeroTarjeta\": \"" + transaccion.NumeroTarjeta + "\",\n \"pin\": \"" + transaccion.PIN + "\",\n \"monto\": "+ transaccion.Monto.ToString() +" }";
    Transaccion(method, uri, body, token);
}

string authentication()
{
    var method = HttpMethod.Post;
    Uri uri = new Uri("https://apiposv120220718002121.azurewebsites.net/pos/api/v1/Autenticacion/validacion");
    string body = "{\n  \"usuario\": \"Banco\",\n  \"password\":   \"123456798\"\n}";
    return GetLogin(method, uri, body);
}

string GetLogin(HttpMethod method, Uri uri, string body)
{
    HttpClient client;
    HttpRequestMessage request;
    string token;
    (client, request) = Get(method, uri, body);
    using (var response = client.Send(request))
    {
        token = GetResponse(response);
    }
    return token;
}

bool Transaccion(HttpMethod method, Uri uri, string body, string token)
{
    HttpClient client;
    HttpRequestMessage request;
    bool flag = false;
    (client, request) = Get1(method, uri, body, token);
    using (var response = client.Send(request))
    {
        flag = GetResponseT(response);
    }
    return flag;
}

(HttpClient, HttpRequestMessage) Get1(HttpMethod method, Uri uri, string body, string token)
{
    var client = new HttpClient();
    var request = new HttpRequestMessage
    {
        Method = method,
        RequestUri = uri,
        Headers =
        {
            { "Authorization", "Bearer "+token},
        },
        Content = new StringContent(body)
        {
            Headers =
            {
                ContentType = new MediaTypeHeaderValue("application/json")
            }
        }
    };
    return (client, request);
}

(HttpClient, HttpRequestMessage) Get(HttpMethod method, Uri uri, string body)
{
    var client = new HttpClient();
    var request = new HttpRequestMessage
    {
        Method = method,
        RequestUri = uri,
        Content = new StringContent(body)
        {
            Headers =
            {
                ContentType = new MediaTypeHeaderValue("application/json")
            }
        }
    };
    return (client, request);
}

string GetResponse(HttpResponseMessage response)
{
    response.EnsureSuccessStatusCode();
    var body = response.Content.ReadAsStringAsync();
    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(body.Result);

    return json.token;
}

bool GetResponseT(HttpResponseMessage response)
{
    if(response.StatusCode == HttpStatusCode.BadRequest)
    {
        Console.WriteLine("\nDatos incorrectos");
        return false;
    }
    if(response.StatusCode == HttpStatusCode.OK)
    {
        Console.WriteLine("\nTransacción Exitosa!");
        return true;
    }
    return false;
}