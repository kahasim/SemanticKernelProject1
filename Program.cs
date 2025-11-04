using System.Text;
using Microsoft.SemanticKernel;

string yourDeploymentName = "gpt";
string yourEndpoint = "https://openai55988525.openai.azure.com/";
string yourKey = "0dc6124408ca48c9bffbb3d3903afe51";

//TODO 1.2 - Create a Kernel builder by using the CreateBuilder method of the Kernel object
var builder = Kernel.CreateBuilder();
// kernel will be configured below and built after services are added

//TODO 1.3 - Configure access to gpt using the AddAzureOpenAIChatCompletion method of the builder's services object
builder.Services.AddAzureOpenAIChatCompletion(
    deploymentName: yourDeploymentName,
    endpoint: yourEndpoint,
    apiKey: yourKey
);

var kernel = builder.Build();

string input;

do {
    Console.WriteLine("Do you have a question?");
    //TODO 1.4 - Gather user input
    input = Console.ReadLine();
     
    //TODO 1.5 - Provide response based on the user input
    if (!string.IsNullOrWhiteSpace(input))    
    {
    var result = await chat.CompleteAsync(input);
        Console.WriteLine(result);
    }
}
while (!string.IsNullOrWhiteSpace(input));
