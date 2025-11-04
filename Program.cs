using System.Text;
using System.Threading.Tasks;
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

// Create a simple local chat stub to satisfy the existing usage of `chat`.
// Replace this with a real chat completion client obtained from `kernel` when ready.
var chat = new ChatStub();

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

class ChatStub
{
    public Task<string> CompleteAsync(string input)
    {
        // Simple echo response to keep the sample working without external services.
        return Task.FromResult($"Echo: {input}");
    }
}
