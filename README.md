## SemicoClient REST API Client for Semico services.

## Demo 
Link https://semico.azurewebsites.net/


### Authentication

Semico uses subscription keys to enable access to the API content and perform requests.

You can register a new Semico subscription key by contacting us at ....

Semico expects for the subscription key to be included in all API requests to the server in the header of the request that looks like the following:

`subscription-key: 23117b5e1a13494cbaf908ca9ac8d8b0`

### Usage

#### Web application

```c#

public void ConfigureServices(IServiceCollection services)
 {
     services.AddExternalTaskClient()
      .ConfigureHttpClient((provider, client) =>
      {
          client.BaseAddress = new Uri("https://nefiavt.azure-api.net");
          client.DefaultRequestHeaders.Add("subscription-key", "23117b5e1a13494cbaf908ca9ac8d8b0");
      });
     
     ....
 }

```

#### Console application

Example of generating a Word document.
```c#
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri("https://nefiavt.azure-api.net");
    
    client.DefaultRequestHeaders.Add("subscription-key", "23117b5e1a13494cbaf908ca9ac8d8b0");
    
    SemicoClientService semicoClient = new SemicoClientService(client);
    
    MemoryStream wordDocument = await semicoClient.GenerateDocument(File.ReadAllBytes(docxTemplatePath), File.ReadAllBytes(jsonPath));
}

```

Example of generating a  PDF document.
```c#
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri("https://nefiavt.azure-api.net");
    
    client.DefaultRequestHeaders.Add("subscription-key", "23117b5e1a13494cbaf908ca9ac8d8b0");
    
    SemicoClientService semicoClient = new SemicoClientService(client);    

    DocumentOptions documentOptions = new DocumentOptions
     {
         ConvertToPdf = true,
         PdfOptions = new PdfOptions
         {
             AdditionalMetadata = "More metadata",
             Application = "Semico Sample Web",
             Author = "Nefia",
             Producer = "Semico",
             Subject = "Semico client",
             Title = "PDF generation",
         }
     };

    MemoryStream pdfDocument = await semicoClient.GenerateDocument(File.ReadAllBytes(docxTemplatePath), File.ReadAllBytes(jsonPath),  documentOptions);
 
}

```

Parameters:
* docxTemplatePath - full path to a Word document (docx)
* jsonPath - full path to a JSON document
* subscription-key - Make sure to replace 23117b5e1a13494cbaf908ca9ac8d8b0 with your subscription key